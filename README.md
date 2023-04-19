# ReactiveMessenger
*<sub>reactive messenger, event bus, observer pattern</sub>*

This is a simple library that helps you send data between modules that you want to keep independent. The library also includes a logger to help you debug signals. 

>I personally recommend using it between gameplay modules, services, and UI modules. However, it is possible to overuse it, which can decrease the readability of the code in the project and create difficulties with debugging.

# Install via UPM 
Add the git url in the unity package manager:
```Http
https://github.com/AlehZakharau/ReactiveMessenger.git?path=/Assets/ReactiveSystem
```
or 
Add the line below in the manifest
```Json
"com.alehzakharau.reactivesystem": "https://github.com/AlehZakharau/ReactiveMessenger.git?path=/Assets/ReactiveSystem",
```

# How to start

To learn more, check the samples in the package.
> You can use the EventBus like a singleton or create an instance and register it in dependency injection.

### Create a signal

```C#
public struct MessageSignal
{
    public float Value;
    public string Message;
    
    public MessageSignal(string message, float value)
    {
        Message = message;
        Value = value;
    }
}
```
### Register the signal in a reciver class
```C#
{
    EventBus.Instance.Subscribe<MessageSignal>(obj => Debug.Log(obj.Message));
    // or
    EventBus.Instance.Subscribe<MessageSignal>(OnMessageArrived);
}

private void OnMessageArrived(MessageSignal obj)
{
    Debug.Log(obj.Message);
    Debug.Log(obj.Value);
}
```
### Send the signal from a sender class

```C#
private void Start()
{
    EventBus.Instance.Fire(new MessageSignal("Hello world", 2));
}
```

### Unsubscribe
If you no longer want to receive messages, you can unsubscribe.
```C#
{
    EventBus.Instance.UnSubscribe<MessageSignal>(OnMessageArrived);
}
```

# Logger

Press "Tools/EventBusLogActivator" to activate the logger. The logger will send messages about Fire, Subscribe, and Unsubscribe to the console.


<img width="169" alt="Screenshot 2023-04-19 at 11 41 32 AM" src="https://user-images.githubusercontent.com/38154177/233128675-37690efa-1163-4a87-a10d-766ec4a8ce7e.png">

# Performance

>I insist on not using it in an update loop.
>
<img width="1470" alt="Screenshot 2023-03-01 at 11 50 19 AM" src="https://user-images.githubusercontent.com/38154177/233130229-2969071f-5dcc-4e13-b401-c00610526b3f.png">

# Author
### [Aleh Zakharau](https://zakharau.notion.site/Aleh-Zakharau-3823f9989352415c8901a81c84681f07)

# Licence
MIT License
