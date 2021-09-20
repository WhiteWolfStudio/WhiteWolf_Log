# Using

``` csharp
// Add script to folder
// Connect file to script or scripts
// for using use

public class TestScript : WW_Log {

    WW_Log l = new WW_Log();
    l.log( $"{date}" );

}

// OR

public class TestScript : WW_Log {

    void Start(){

        log( $"Editor: {editor}" );
        log( $"Path: {path}" );

    }

}

```

``` csharp
// Editor | TRUE or FALSE
public bool editor;

// Editor |  PATH = "Assets/file.log"
//  Game  |  PATH = Application.persistentDataPath
public string path;
```
