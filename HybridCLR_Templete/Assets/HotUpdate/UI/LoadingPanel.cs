using Templete;
using FairyGUI;

public class LoadingPanel : BasePanel<LoadingPanel>
{
    public GLoader bg;
    public GProgressBar bar;
    public GTextField title;
    public GTextField percent;
    public float curValue;
    public override void Create()
    {
        updateSetting = () =>
        {
            setting.pkgName = "Yango";
            setting.resName = "LoadingPanel";
            setting.layer = "layer1";
            setting.fullScreen = true;
        };
        base.Create();
    }
    public override void Awake(FGUIInstance _inst)
    {
        getComs = () =>
        {
            bg = root.GetChild("bg").asLoader;
            bar = root.GetChild("bar").asProgress;
            title = root.GetChild("title").asTextField;
            percent = root.GetChild("percent").asTextField;
        };
        base.Awake(_inst);
    }
    public void SetValue(float value)
    {
        if (Ready)
        {
            bar.value = value;
            curValue = value;
            percent.text = $"{value * 100}%";
        }
    }
}
