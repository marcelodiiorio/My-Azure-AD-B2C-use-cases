The PhoneFactor claims provider can be modified to prevent users entering a new phone number during different actions that may trigger MFA. This is done by setting the property "ManualPhoneNumberEntryAllowed" from true to false.

Take into account if you require MFA to an account that doesn't have a phone number registered (verified.StrongAuthenticationPhoneNumber, or Phone in "Authentication contact info" (Users and groups blade)) then B2C will throw you an error saying that there is no phone registered for MFA, and manual registration is disabled.

This is useful in cases where manual registration of phone numbers is a requirement.

The PhoneFactor claim provider can be found in the policies that are part of the B2C custom policies starter pack, inside those that are related to MFA.

If you prevent users from entering a new phone number and they don't have one registered, then they will be an error like this one:

https://jwt.io/#error=server_error&error_description=AADB2C90145%3a+No+unverified+phone+numbers+have+been+found+and+policy+does+not+allow+a+user+entered+number.%0d%0aCorrelation+ID%3a+c0b9a58e-4104-425a-a437-9fc3fa34cf57%0d%0aTimestamp%3a+2018-03-14+09%3a26%3a17Z%0d%0a

You must also add

```xml
<OutputClaim ClaimTypeReferenceId="strongAuthenticationPhoneNumber" />
```

To the technical profile that reads the user from AAD B2C directory. For example, in case of social logins, is AAD-UserReadUsingAlternativeSecurityId. In case of ADFS and other custom providers, you must add it to the corresponding technical profile.

