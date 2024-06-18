### Imato.Logger.Extensions
Useful logger Extensions

#### Simplify logging

```
logger?.LogInformation(() => "My message");
logger?.LogInformation(() => new object { myData = "Test" });
```

#### Log task duration

```
await logger?.LogInformation(() => MyLongRunningTask(), "Ima working");
```
