# Nullable Extensions

This is a set of extension methods for C# nullable types (reference types and Nullable<T>)
that allow you to ger rid of null checks using if statements and ternary operators.
This draws inspiration from Rust.

## Methods
- [Inspect](#inspect)
- [WhenNull](#whennull)
- [Is](#is)
- [Map](#map)
- [ValueOr](#valueor)

### Inspect

The `Inspect()` methods performs an action against the value if the value is not null.

```csharp
var product = products.FirstOrDefault(p => p.Code == Code);
product.Inspect(product => product.UpdatedDate = DateTime.NowUtc);
```

In addition to that `Inspect()` has async overloads.
```csharp
var delivery = await delivery.GetProductAsync(id);
product.InspectAsync(p => {
    p.Address = await addressService.GetByPostalCodeAsync(p.PostlCode)
});
```

Some of the overloads actually extend the `ValueTask<T>` class,
so instead of inspecting a task they inspect the output of the task:

```csharp
await serializer.SerializeAsync()
    .InspectAsync(message => processor.ProcessAsync(message));
```

```csharp
await serializer.SerializeAsync()
    .InspectAsync(message => logger.LogInformation(message));
```

### WhenNull

This method as opposed to `Inspect()` call the delegate when the value is null.

```csharp
await serializer.Serialize()
    .WhenNull(message => logger.LogError("Failed to serialize message!"));
```

Since `Inspect()` and `WhenNull()` return the unchanged value you can combine these methods:

```csharp
await serializer.Serialize()
    .WhenNull(() => logger.LogError("Failed to serialize message!"))
    .Inspect(message => logger.LogInformation(message))
    .Inspect(message => processor.Process(message));
```

`WhenNull()` has the same set of async overloads as `Inspect()`.

```csharp
await serializer.SerializeAsync()
    .WhenNullAsync(() => logger.NotifyAsync("Failed to serialize a message!"));
});
```

```csharp
await serializer.SerializeAsync()
    .WhenNullAsync(() => logger.LogError("Failed to serialize a message!"));
```

```csharp
await serializer.Serialize()
    .WhenNullAsync(() => notifier.NotifyAsync("Failed to serialize message!"));
```

### Is

Checks if the underlying value is not null. If so, it'll run specified predicate.

```csharp
var user = userService.GetUser(id);
user.Is(u => u.EmailAddress == emailAddress);
```

Also, async overloads available.

### Map

### ValueOr
