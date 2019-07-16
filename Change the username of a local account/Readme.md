# Sample set of custom policies to update the username of existing Azure AD B2C local accounts.

The policies involved are:

<b>ChangeSignInName.xml</b>: This is the one that invokes the user journey to update the signInNames.userName element of the signInNames collection.

<b>SignUpOrSignIn.xml</b>: To sign-up or sign-in.

<b>TrustFrameworkExtensions.xml</b>: This one contains different claim providers and the changeUserName user journey.

<b>TrustFrameworBase.xml</b>: This one contains the claims schema, where I have added the signInNames elements mentioned above, plus different technical profiles that are part of the flow.

For details, see the comments inside each policy. You have to change different references to point to your tenant, like:
	- TenantId.
	- PolicyId.
	- Proxy and IEF app Ids.

This use case is based on the Azure AD B2C samples available in https://github.com/azure-ad-b2c/samples

Basic flow:

1. You can sign-in using username or email. In both cases you will receive a verification code to the email registered.
2. If it's a new user, then sign-up first.
3. If it's an existing user, then sign-in.
4. Validate the email provided by entering a code and after that, change the username

	<ul>If the username is already taken by another local account, an error is displayed.</ul>

	<ul>If the username is the same the user is trying to use, no error is displayed.</ul>

	<ul>If the username is different that the existing one and not in use, then it's updated.</ul>

Credits to the AAD B2C GTP team for the samples I have used as source.
