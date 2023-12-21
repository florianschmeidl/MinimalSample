using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public class ViewFactory : IViewFactory
    {
        // Dependencies
        private readonly PanelSettings m_DefaultPanelSettings;

        // Constructors
        public ViewFactory(PanelSettings defaultPanelSettings)
        {
            m_DefaultPanelSettings = defaultPanelSettings;
        }

        // Methods
        public UIDocument Make(ViewType viewType, VisualTreeAsset visualTreeAsset)
        {
            var gameObject = new GameObject($"{viewType.ToString()}_UiDocument");
            var uiDocument = gameObject.AddComponent<UIDocument>();
            uiDocument.visualTreeAsset = visualTreeAsset;
            
            var panelSettings = ScriptableObject.Instantiate(m_DefaultPanelSettings);
            var renderTexture = new RenderTexture(1920, 1080, 
                GraphicsFormat.R32G32B32A32_SFloat, GraphicsFormat.None);
            panelSettings.targetTexture = renderTexture;
            uiDocument.panelSettings = panelSettings;

            var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            quad.name = viewType.ToString();
            quad.transform.localScale = new Vector3(16, 9, 1);
            gameObject.transform.SetParent(quad.transform);
            var material = new Material(Shader.Find("Standard"));
            material.mainTexture = renderTexture;
            var meshRenderer = quad.GetComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = material;

            return uiDocument;
        }
    }
}