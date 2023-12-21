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
        private List<KeyValuePair<ViewType, UIDocument>> m_CurrentViews = new List<KeyValuePair<ViewType, UIDocument>>();
        
        // Constructors
        public ViewValidator(IUIFactory uiFactory)
        {
            m_UIFactory = uiFactory;
        }

        public async Awaitable AddView(ViewType viewType)
        {
            if (NeedsSpawn(viewType))
            {
                var uiDocument = await m_UIFactory.Make(viewType);
                m_CurrentViews.Add(new KeyValuePair<ViewType, UIDocument>(viewType, uiDocument));     
            }
        }
        
        public async void UpdateViews(ViewType[] mandatoryViews, params ViewType[] optionalViews)
        {
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