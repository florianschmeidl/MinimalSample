using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    [CreateAssetMenu(menuName = "Straumann/VisualTreeDatabase")]
    public class VisualTreeDatabase : ScriptableObject, IVisualTreeDatabase
    {
        [Serializable]
        public class DatabaseEntry
        {
            public ViewType ViewType;
            public VisualTreeAsset VisualTreeAsset;
        }

        // Properties
        public DatabaseEntry[] DatabaseEntries => m_DatabaseEntries;
        
        // Members
        [SerializeField] private DatabaseEntry[] m_DatabaseEntries = Array.Empty<DatabaseEntry>();
    }
}