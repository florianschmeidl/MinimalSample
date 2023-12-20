    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Unity.Properties;
    using UnityEngine.UIElements;

    [UxmlObject]
    public sealed partial class ActionBinding : CustomBinding, IDataSourceProvider {
        static readonly PropertyInfo propertyPropertyInfo =
            typeof(Binding).GetProperty("property", BindingFlags.Instance | BindingFlags.NonPublic)!;
 
        static readonly Dictionary<(Type, string), EventInfo> _eventInfos = new();
 
        Action? _onAction;
 
        public ActionBinding() {
            updateTrigger = BindingUpdateTrigger.OnSourceChanged;
        }
 
        public string Property {
            get => (string)propertyPropertyInfo.GetValue(this)!;
            set => propertyPropertyInfo.SetValue(this, value);
        }
 
        public object? dataSource { get; set; }
        public PropertyPath dataSourcePath { get; set; }
 
        [UxmlAttribute("data-source-path")]
        public string DataSourcePathString {
            get => dataSourcePath.ToString();
            set => dataSourcePath = new PropertyPath(value);
        }
 
        static EventInfo GetEventInfo(Type type, string name) {
            if (_eventInfos.TryGetValue((type, name), out var eventInfo)) return eventInfo;
            eventInfo = type.GetEvent(name);
            _eventInfos.Add((type, name), eventInfo);
            return eventInfo;
        }
 
        protected override void OnDataSourceChanged(in DataSourceContextChanged context) {
            var element = context.targetElement;
            var type = element.GetType();
            var eventInfo = GetEventInfo(type, Property);
            if (_onAction is not null) eventInfo.RemoveEventHandler(element, _onAction);
            var source = context.newContext.dataSource;
            if (source is null) return;
            var path = context.newContext.dataSourcePath;
            if (!PropertyContainer.TryGetValue(ref source, in path, out _onAction)) return;
            eventInfo.AddEventHandler(element, _onAction);
        }
    }
