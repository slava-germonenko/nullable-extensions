# Nullable Extensions

This is a set of extension methods for C# nullable types (reference types and the Nullable<T> struct)
that allow you to ger rid of if statements used to check for null.

## Methods
- [Inspect](#inspect)
- [WhenNull](#whennull)
- [Is](#is)
- [Map](#map)
- [ValueOr](#valueor)

All of these methods has async overloads.
You can find them in `SG.NullableExtensions.Tasks` and `SG.NullableExtensions.ValueTasks` namespaces.

### Inspect

`Inspect()` performs an action against a value if the value is not null.

```csharp
var product = products.FirstOrDefault(p => p.Code == Code);
product.Inspect(product => product.UpdatedDate = DateTime.NowUtc);
```

`Inspect()` has async overloads that support both `Task<T>` and `ValueTask<T>`:

```csharp
var delivery = await delivery.GetProductAsync(id);
await product.InspectAsync(p => {
    p.Address = await addressService.GetByPostalCodeAsync(p.PostlCode)
});
```

In addition to that, there are extensions for `ValueTask<T?>` and `Task<T?>`,
they will await the given tasks for you if needed, so the `Inspect()` is applied to the output of the task. 

```csharp
await serializer.SerializeAsync()
    .InspectAsync(message => processor.ProcessAsync(message)) // takes Task<T?>, applies Func<T, Task>
    .InspectAsync(message => logger.LogInformation(message)) // takes Task<T?>, applies Action<T>;
```

### WhenNull

This method as opposed to `Inspect()` calls the delegate when the value is null.

```csharp
await serializer.Serialize()
    .WhenNull(message => logger.LogError("Failed to serialize a message!"));
```

Please, note: `Inspect()` and `WhenNull()` return the unchanged value, so you can combine these methods:

```csharp
await serializer.Serialize()
    .WhenNull(() => logger.LogError("Failed to serialize message!"))
    .Inspect(message => logger.LogInformation(message))
    .Inspect(message => processor.Process(message));
```

`WhenNull()` has the same set of async overloads as `Inspect()`.

```csharp
await serializer.SerializeAsync()
    .WhenNullAsync(() => logger.NotifyAsync("Failed to serialize a message!")); // takes Task<T?>, applies Func<Task>
});

await serializer.SerializeAsync()
    .WhenNullAsync(() => logger.LogError("Failed to serialize a message!")); // takes Task<T?>, applies Action

await serializer.Serialize()
    .WhenNullAsync(() => notifier.NotifyAsync("Failed to serialize message!")); // takes T?, applies Func<Task>
```

### Is

Checks if the underlying value is not null. If so, it'll run specified predicate.

```csharp
var user = userService.GetUser(id);
user.Is(u => u.EmailAddress == emailAddress);
```

Also, async overloads available.

```csharp
var user = userService.GetUser(id);
await user.IsAsync(u => userOrderService.HasPendingOrdersAsync(u.Id));

await userService.GetUserAsync(id).IsAsync(u => userOrderService.HasPendingOrdersAsync(u.Id));
```

### Map

Transforms the underlying value if it is not null.
```csharp
var user = await dbContext.User
    .FirstOrDefault(u => u.Id == id)
    .Map(u => new UserModel(u));
```

Supports an async overload:

```csharp
var body = await httpContext.Read()
    .MapAsync(b => JsonSerializer.DeserializeAsync<User>(u));
```

`ValueTask<T?>` and `Task<T?>` overloads are supported as well:

```csharp
var authorizationResult = await httpContext.ReadAsJsonAsync<Credentials>()
    .MapAsync(credentials => authService.AuthorizeAsync(credentials));

var userDto = await httpContext.ReadAsJsonAsync<User>()
    .MapAsync(credentials => mapper.Map<UserDto>());
```

### ValueOr

Tries to unwrap the underlying value.
If the value is null, it will return specified default value.

```csharp
var address = employee.Address.ValueOr(new Address());
```

Also, there is an overload that uses a factory instead of a plain value.

```csharp
var address = employee.Address.ValueOr(() => addressService.GetDefaultAddress());
```

There are also async overloads including `ValueTas<T>` and `Task<T>` extensions.
```csharp
var apiKey = await apiKeysCache
    .Get()
    .ValueOrAsync(() => await apiKeysService.RefreshAsync())
    .InspectAsync(key => await apiKeysCache.SetAsync(key))
    
var apiKey = await apiKeysCache
    .GetAsync()
    .ValueOrAsync(() => await apiKeysService.RefreshAsync()) // takes Task<T?>, applies Func<Task>
    .InspectAsync(key => await apiKeysCache.SetAsync(key))
    
var apiKey = await apiKeysCache
    .GetAsync()
    .ValueOrAsync(() => apiKeysService.Refresh()) // takes Task<T?>, applies Action
    .InspectAsync(key => apiKeysCache.SetAsync(key))
```
