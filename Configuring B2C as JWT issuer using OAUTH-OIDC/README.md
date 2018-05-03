This is a sample set of policies to test SSO.

Things to consider:

https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-reference-sso-custom
https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-reference-manage-sso-and-token-configuration

Basically:

- Add all the technical profiles for session management described in the documents above, as well as the session behavior setting in the RP policies.
- The claims bag must persist the claims of your need.
- If there is a claim missing in the claims bag, you well get an error related to a missing claim in the claims collection. The error tells you what is the missing claim.
- Remove &prompt_login from the URL of the policy you are running to test SSO. For example:

Original URL: https://login.microsoftonline.com/mdiioriob2c.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1A_SignUpOrSignIn-OIDC&client_id=d72eacfc-4ce2-4f86-a859-fc8da75fba50&nonce=defaultNonce&redirect_uri=https%3A%2F%2Fjwt.io&scope=openid&response_type=id_token&prompt=login

Without &prompt=login

https://login.microsoftonline.com/mdiioriob2c.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1A_SignUpOrSignIn-OIDC&client_id=d72eacfc-4ce2-4f86-a859-fc8da75fba50&nonce=defaultNonce&redirect_uri=https%3A%2F%2Fjwt.io&scope=openid&response_type=id_token

An easy test you  can do:

1. Run any policy, even those related to SAML/WS-Fed issuers, and sign-in. Don't close the browser.
2. Open a new tab and run the policy mentioned above, without &prompt=login.
3. You should experience SSO.



