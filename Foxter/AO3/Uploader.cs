using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.AO3
{
    internal class Uploader
    {
        private Ao3Session _session;
        private HttpClient _http;
        private string _url;
        public Uploader(Ao3Session session)
        {
            _session = session;
            if (_session.Autenticated == false)
            {
                throw new Ao3ForbiddenException("session not authenticated");
            }
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                CookieContainer = _session.SessionCookies
            };

            _http = new HttpClient(handler);
            _url = "https://archiveofourown.org/";
        }

        string GetAuthenticityToken(string draftHtml)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(draftHtml);
            var authenticityToken = htmlDoc.DocumentNode
                .SelectSingleNode("//meta[@name='csrf-token']")
                .GetAttributeValue("content", null);
            return authenticityToken;
        }

        private Ao3Draft ConvertHtmlToDraftObj(string draftHtml)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(draftHtml);
            var work = new Ao3Draft();
            var chapterTitle = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"chapter_title\"]")
                .GetAttributeValue("value", "");
            work.ChapterTitle = chapterTitle;

            var chapterPosition = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"chapter_position\"]")
                .GetAttributeValue("value", "");
            work.Position = chapterPosition;

            var chapterWipLength = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"chapter_wip_length\"]")
                .GetAttributeValue("value", "");
            work.WipLength = chapterWipLength;

            var publishedAtDay = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//select[@id=\"chapter_published_at_3i\"]//option[@selected=\"selected\"]")
                .GetAttributeValue("value", "");
            work.PublishedAtDay = publishedAtDay;

            var publishedAtMonth = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//select[@id=\"chapter_published_at_2i\"]//option[@selected=\"selected\"]")
                .GetAttributeValue("value", "");
            work.PublishedAtMonth = publishedAtMonth;

            var publishedAtYear = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//select[@id=\"chapter_published_at_1i\"]//option[@selected=\"selected\"]")
                .GetAttributeValue("value", "");
            work.PublishedAtYear = publishedAtYear;


            var authorsById = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"chapter_author_attributes_ids\"]")
                .GetAttributeValue("value", "");
            work.AuthorsById = authorsById;


            var authorsByLine = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"pseud_byline\"]")
                .GetAttributeValue("value", "");
            work.AuthorByLine = authorsByLine;

            var summary = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//textarea[@id=\"chapter_summary\"]")
                .InnerHtml;
            work.Summary = summary;

            var showFrontNotes = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"front-notes-options-show\"]")
                .GetAttributeValue("value", "0");
            work.ShowFrontNotes = showFrontNotes;

            var notes = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//textarea[@id=\"chapter_notes\"]")
                .InnerHtml;
            work.Notes = notes;

            var showEndNotes = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//input[@id=\"end-notes-options-show\"]")
                .GetAttributeValue("value", "0");
            work.ShowEndNotes = showEndNotes;

            var endNotes = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//textarea[@id=\"chapter_endnotes\"]")
                .InnerHtml;
            work.EndNotes = endNotes;

            var content = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id=\"chapter-form\"]//textarea[@id=\"content\"]")
                .InnerHtml;
            work.Content = WebUtility.HtmlDecode(content);
            return work;
        }

        public async Task<bool> PostDraft(int storyId, int draftId)
        {
            var rawDraftHtml = await _http.GetStringAsync(_url + $"/works/{storyId}/chapters/{draftId}/edit");
            string token = GetAuthenticityToken(rawDraftHtml);
            Ao3Draft draft = ConvertHtmlToDraftObj(rawDraftHtml);

            var contents = new FormUrlEncodedContent(new Dictionary<string, string>{
                    {"_method", "patch" },
                    {"authenticity_token", token},
                    {"chapter[title]", draft.ChapterTitle },
                    {"chapter[position]", Convert.ToString(draft.Position) },
                    {"chapter[wip_length]", Convert.ToString(draft.WipLength) },
                    {"chapter[published_at(3i)]",draft.PublishedAtDay },
                    {"chapter[published_at(2i)]", draft.PublishedAtMonth },
                    {"chapter[published_at(1i)]", draft.PublishedAtYear },
                    {"chapter[author_attributes][ids][]", draft.AuthorsById},
                    {"chapter[author_attributes][byline]", draft.AuthorByLine }, // I have no idea what this does
                    {"chapter[summary]", draft.Summary },
                    {"front-notes-options-show", draft.ShowFrontNotes},
                    {"chapter[notes]", draft.Notes },
                    {"end-notes-options-show", draft.ShowEndNotes },
                    {"chapter[endnotes]", draft.EndNotes },
                    {"chapter[content]", draft.Content },
                    {"post_without_preview_button", "Post" }
                });


            var response = await _http.PostAsync(_url + $"/works/{storyId}/chapters/{draftId}", contents);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString.Contains("<div class=\"flash notice\">Chapter was successfully posted.</div>") ||
                   responseString.Contains("<div class=\"flash notice\">Chapter was successfully updated.</div>");

        }

    }
}
