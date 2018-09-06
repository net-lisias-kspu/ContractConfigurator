using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace ContractConfigurator.Util
{
    public static class DebuggingUtils
    {
        public static Transform FindDeepChild(this Transform parent, string name)
        {
            var result = parent.Find(name);
            if (result != null)
                return result;
            foreach (Transform child in parent)
            {
                result = child.FindDeepChild(name);
                if (result != null)
                    return result;
            }
            return null;
        }

        public static void Dump(this GameObject go, string indent = "")
        {
            for (int i = go.GetComponents<Component>().Length - 1; i >= 0; i--)
            {
                Component c = go.GetComponents<Component>()[i];
                Debug.Log(indent + c);
                if (c is KerbalInstructor)
                {
                    return;
                }
            }

            foreach (Transform c in go.transform)
            {
                c.gameObject.Dump(indent + "    ");
            }
        }

        public static void DumpDetails(this System.Object o, string text = null)
        {
            Debug.Log(!string.IsNullOrEmpty(text) ? text : "Dumping object:");

            for (int i = o.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | BindingFlags.FlattenHierarchy).Length - 1; i >= 0; i--)
            {
                FieldInfo fi = o.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | BindingFlags.FlattenHierarchy)[i];
                Debug.Log(string.Format("    {0} = {1}", fi.Name, fi.GetValue(o)));
            }

            for (int i = o.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | BindingFlags.FlattenHierarchy).Length - 1; i >= 0; i--)
            {
                PropertyInfo pi = o.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | BindingFlags.FlattenHierarchy)[i];
                Debug.Log(string.Format("    {0} = {1}", pi.Name, pi.GetValue(o, null)));
            }
        }
    }
}
