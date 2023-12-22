using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public class ViewValidator : IViewValidator
    {
        // Dependencies
        private readonly IUIFactory m_UIFactory;

        // Members
        private readonly List<KeyValuePair<ViewType, UIDocument>> m_CurrentViews = new();
        
        // Constructors
        public ViewValidator(IUIFactory uiFactory)
        {
            m_UIFactory = uiFactory;
        }

        public async Awaitable AddView(ViewType viewType)
        {
            // TODO: With this implementation we can't spawn new views of the same type, 
            // since their view type is are already registered in the current view list
            if (NeedsSpawn(viewType))
            {
                var uiDocument = await m_UIFactory.Make(viewType);
                m_CurrentViews.Add(new KeyValuePair<ViewType, UIDocument>(viewType, uiDocument));     
            }
        }
        
        public async void UpdateViews(ViewType[] mandatoryViews, params ViewType[] optionalViews)
        {
            // TODO: we need to destroy the views before we instantiate the new ones
            foreach (var mandatoryView in mandatoryViews)
            {
                await AddView(mandatoryView);
            }

            var elementsToBeDestroyed = new List<KeyValuePair<ViewType, UIDocument>>();
            
            foreach (var keyValuePair in m_CurrentViews)
            {
                if (mandatoryViews.Contains(keyValuePair.Key) == false &&
                    optionalViews.Contains(keyValuePair.Key) == false)
                {
                    elementsToBeDestroyed.Add(keyValuePair);
                }
            }

            foreach (var elementToBeDestroyed in elementsToBeDestroyed)
            {
                m_CurrentViews.Remove(elementToBeDestroyed);
                var uiDocument = elementToBeDestroyed.Value;
                var panelSettings = uiDocument.panelSettings;
                GameObject.Destroy(panelSettings.targetTexture);
                GameObject.Destroy(panelSettings);
                GameObject.Destroy(uiDocument.transform.parent.gameObject);
            }
        }

        private bool NeedsSpawn(ViewType viewType)
        {
            foreach (var keyValuePair in m_CurrentViews)
            {
                if (keyValuePair.Key == viewType)
                    return false;
            }
            return true;
        }
    }
}