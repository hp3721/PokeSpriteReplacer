using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Reflection;
using System.Resources;
using System.IO;

namespace SpriteReplacer
{
    public class SpriteReplacerPlugin : IPlugin
    {
        public string Name => nameof(SpriteReplacerPlugin);
        public int Priority => 1;

        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);

            if (!File.Exists(Path.Combine(Application.StartupPath, "PokeSprite.resources")))
                return;

            var PokeSpriteResources = Assembly.Load("PKHeX.Drawing.PokeSprite").GetType("PKHeX.Drawing.PokeSprite.Properties.Resources");
            var resourceMan_f = PokeSpriteResources.GetField("resourceMan", BindingFlags.NonPublic | BindingFlags.Static);
            resourceMan_f.SetValue(null, ResourceManager.CreateFileBasedResourceManager("PokeSprite", Application.StartupPath, null));

            var ParentForm = ((ContainerControl)SaveFileEditor).ParentForm;
            ParentForm.GetType().GetMethod("PKME_Tabs_UpdatePreviewSprite", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(ParentForm, new object[] { new object(), EventArgs.Empty });
        }

        public void NotifySaveLoaded(){}

        public bool TryLoadFile(string filePath){return false;}
    }
}
