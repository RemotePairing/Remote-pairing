# RemotePairing ![](https://codinghappinness.visualstudio.com/_apis/public/build/definitions/cc6288d3-1203-481b-9e3d-d053a0552d51/2/badge)
ASP.NET MVC project - it is meant to bring functionality of pairing programmers (especially strangers) to explore this programming technique together. Application has started during [GetNoticed!](dajsiepoznac.pl) contest.

To build the project correctly add Secret.config file at the root folder of the project and fill it with GitHub ClientID and SecretID. Sample:

<appSettings>
	<add key="GitHubClientId" value="5d5d5d5d5d5d5d" />
	<add key="GitHubSecretId" value="c4c4c4c4c4c4c4c4c4c" />
</appSettings>
