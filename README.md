# NntpLib.Net <a href="http://ci.hellang.com/viewType.html?buildTypeId=NNTP_Master&tab=buildTypeStatusDiv&guest=1"><img src="http://ci.hellang.com/app/rest/builds/buildType:(id:NNTP_Master)/statusIcon"/></a>
An [RFC 3977](http://tools.ietf.org/pdf/rfc3977.pdf) and [RFC 4643](http://tools.ietf.org/pdf/rfc4643.pdf) compliant NNTP client library for .NET, written in C#.

## Usage

To use the library, you have two options:

### 1. NntpConnection

`NntpConnection` provides the library's lowest level of NNTP communication. The class only has 4 public methods:

```csharp
NntpResponse Connect(string hostname, int port, bool useSsl);

NntpResponse ExecuteCommand(string command);

NntpMultilineResponse ExecuteMultilineCommand(string command, int validCode);

void Close();
```

With this, you can execute commands independently and inspect the responses directly. Using this will give you full control, but will also require some knowledge of the NNTP protocol and its commands. All commands are implemented as extension methods to `INntpConnection` and will call either `ExecuteCommand` or `ExecuteMultilineCommand` with the correct parameters.

### 2. NntpClient

Description for `NntpClient` is coming soon...
