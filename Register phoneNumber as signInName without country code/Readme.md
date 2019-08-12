# Sample set of custom policies to store different values in the signInNames collection in the following way:

	- signInNames.userName.
	- signInNames.emailAddresses.
	- signInNames.phoneNumber (without country code).

The policies involved are:

	- SignUpOrSigninPhoneNoCountryCode. This one calls the SignUpOrSignIn user journey located in the base policy.
	- TrustFrameworkExtensionsPhoneNoCountryCode. There is nothing in particular in this policy at this time, however the user journey can be moved into the extensions
	  policy if desired.
	- TrustFrameworkBasePhoneNoCountryCode. This is where everything happens.

For details, see the comments inside each policy. You have to change different references to point to your tenant, like:
	- TenantId.
	- PolicyId.
	- Proxy and IEF app Ids.
	- The service URL of your Azure Functions function.
	- Any particular claim used in the use case, in case you decide to use different names.

This use case is based on the Azure AD B2C samples available in https://github.com/azure-ad-b2c/samples

Basic flow:

1. Sign-up using local accounts.
2. Confirm the code received in your email.
3. Fill the sign-up form.
4. Go through MFA to register your mobile phone.

You can add the following claims, among others, to see the values stored:

	- signInNames.emailAddresses.
	- signInNames.phoneNumber (it will output the phone number without country code).
	- strongAuthenticationPhoneNumber. To output the phone number as it was registered in the authentication contact info.
	- signInNames.userName.
	- phoneNumberWithCountryCode. It will output the same value stored in the strongAuthenticationPhoneNumber.
	- phoneNumberNoCountryCode. It will output the same value stored in the signInNames.phoneNumber claim.

Credits to the AAD B2C GTP team for the samples I have used as source.
