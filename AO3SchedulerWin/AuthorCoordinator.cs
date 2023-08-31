using AO3SchedulerWin.Controllers.AuthorControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin
{
    
    
    internal sealed class AuthorCoordinator
    {
        //Singleton Implementation
        private static readonly Lazy<AuthorCoordinator> _instance = new Lazy<AuthorCoordinator>(() => new AuthorCoordinator());
        public static AuthorCoordinator Get => _instance.Value;
        
        private AuthorCoordinator()
        {

        }
        
        //General Purpose
        private List<IAuthorController> _coordinatedObjects = new List<IAuthorController>();


                
        public void NotifyAll()
        {
            foreach (var obj in _coordinatedObjects) obj.UpdateViews();
        }
        public IAuthorController MakeCoorinatedObject(IAuthorController controller)
        {
            _coordinatedObjects.Add(controller);
            return controller;
        }

        public void ReleaseCoordinatedObject(IAuthorController controller)
        {
            _coordinatedObjects.Remove(controller);
        }

    }
}
