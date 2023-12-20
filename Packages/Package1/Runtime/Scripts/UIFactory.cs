using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public class UIFactory : IUIFactory
    {
        // Dependencies
        private readonly IVisualTreeProvider m_VisualTreeProvider;
        private readonly PanelSettings m_DefaultPanelSettings;

        // Constructors
        public UIFactory(IVisualTreeProvider visualTreeProvider, PanelSettings defaultPanelSettings)
        {
            m_VisualTreeProvider = visualTreeProvider;
            m_DefaultPanelSettings = defaultPanelSettings;
        }

        public async Awaitable<UIDocument> Make(string name)
        {
            VisualTreeAsset visualTreeAsset = await m_VisualTreeProvider.GetAsync(name);

            var gameObject = new GameObject(name);
            var uiDocument = gameObject.AddComponent<UIDocument>();
            uiDocument.visualTreeAsset = visualTreeAsset;

            var panelSettings = ScriptableObject.Instantiate(m_DefaultPanelSettings);
            var renderTexture = new RenderTexture(1920, 1080, 
                GraphicsFormat.R32G32B32A32_SFloat, GraphicsFormat.None);
            panelSettings.targetTexture = renderTexture;
            uiDocument.panelSettings = panelSettings;

            var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
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