using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;

namespace ContractConfigurator.CutScene
{
    public class CutSceneDefinition
    {
        public string name;
        public List<CutSceneCamera> cameras = new List<CutSceneCamera>();
        public List<Actor> actors = new List<Actor>();
        public List<CutSceneAction> actions = new List<CutSceneAction>();

        public float aspectRatio = 2.35f;

        public CutSceneDefinition()
        {
        }

        public void Save(string fileURL)
        {
            ConfigNode configNode = new ConfigNode("CUTSCENE_DEFINITION");
            
            string fullPath = string.Join(Path.DirectorySeparatorChar.ToString(), new string[] {
                KSPUtil.ApplicationRootPath, "GameData", fileURL });

            OnSave(configNode);

            configNode.Save(fullPath);
        }

        public void Load(string fileURL)
        {
            string fullPath = string.Join(Path.DirectorySeparatorChar.ToString(), new string[] {
                KSPUtil.ApplicationRootPath, "GameData", fileURL });
            ConfigNode configNode = ConfigNode.Load(fullPath);

            OnLoad(configNode.GetNode("CUTSCENE_DEFINITION"));
        }

        public void OnSave(ConfigNode configNode)
        {
            configNode.AddValue("name", name);
            configNode.AddValue("aspectRatio", aspectRatio);

            for (int i = cameras.Count - 1; i >= 0; i--)
            {
                CutSceneCamera cameraDefinition = cameras[i];
                ConfigNode child = new ConfigNode(cameraDefinition.GetType().Name);
                configNode.AddNode(child);

                cameraDefinition.OnSave(child);
            }

            for (int i = actors.Count - 1; i >= 0; i--)
            {
                Actor actor = actors[i];
                ConfigNode child = new ConfigNode(actor.GetType().Name);
                configNode.AddNode(child);

                actor.OnSave(child);
            }

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                CutSceneAction action = actions[i];
                ConfigNode child = new ConfigNode(action.GetType().Name);
                configNode.AddNode(child);

                action.OnSave(child);
            }
        }

        public void OnLoad(ConfigNode configNode)
        {
            name = ConfigNodeUtil.ParseValue<string>(configNode, "name");
            aspectRatio = ConfigNodeUtil.ParseValue<float>(configNode, "aspectRatio");

            for (int i = configNode.GetNodes().Length - 1; i >= 0; i--)
            {
                ConfigNode child = configNode.GetNodes()[i];
                Type nodeType = ConfigNodeUtil.ParseTypeValue(child.name);
                if (nodeType.IsSubclassOf(typeof(CutSceneCamera)))
                {
                    CutSceneCamera cameraDefinition = Activator.CreateInstance(nodeType) as CutSceneCamera;
                    cameraDefinition.OnLoad(child);
                    cameras.Add(cameraDefinition);
                }
                else if (nodeType.IsSubclassOf(typeof(Actor)))
                {
                    Actor actor = Activator.CreateInstance(nodeType) as Actor;
                    actor.OnLoad(child);
                    actors.Add(actor);
                }
                else if (nodeType.IsSubclassOf(typeof(CutSceneAction)))
                {
                    CutSceneAction action = Activator.CreateInstance(nodeType) as CutSceneAction;
                    action.cutSceneDefinition = this;
                    action.OnLoad(child);
                    actions.Add(action);
                }
                else
                {
                    LoggingUtil.LogError(this, "Couldn't load CutSceneDefinition - unknown type '" + child.name + "'.");
                }
            }
        }

        public CutSceneCamera camera(string name)
        {
            return cameras.FirstOrDefault(c => c.name == name);
        }

        public Actor actor(string name)
        {
            return actors.FirstOrDefault(a => a.name == name);
        }
    }
}
