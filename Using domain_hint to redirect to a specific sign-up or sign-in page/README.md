Domain_hint can be used to redirect users to a specific identity provider sign-up or sign-in page, instead of having to choose between multiple identity providers. This is useful in cases where you have many identity providers configured in the same policy, or when you want to simplify the user experience, for example.

for this example, you will need:

	- A claims provider with the "<domain>" property configured.
	- a URL with the domain_hint property added. For example https://login.microsoftonline.com/mdiioriob2c.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1A_signup_signinWithAAD&client_id=d72eacfc-4ce2-4f86-a859-fc8da75fba50&nonce=defaultNonce&redirect_uri=https%3A%2F%2Fjwt.io&scope=openid&response_type=id_token&prompt=login&domain_hint=mdiiorio
	- The domain property value must match the value specified in the domain_hint property, in the URL.
	
The XML policy file only contains the claims provider that must be added to your policy. In general, claims providers are contained in the extensions or base policy. As you may know, you may even have everything in a single policy.

This claims provider must be called from the orchestration step related to the IdP selection. From the relying party policy, you must call a DefaultUserJourney that contains all this and additional orchestration steps, and from the orchestration step, you must call the corresponding claims provider.
