public class CoffeeInteractable : Interactable
{
    public TaskManager manager;
    [FMODUnity.EventRef]
    public string soundEvent;

    private void Start()
    {
        
    }

    public override void AccessTask()
    {
        if (!enabled)
            return;
        var instance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        instance.start();
        instance.release();
        manager.Success();
        enabled = false;
    }
}
