The PhoneFactor claim provider can be modified to prevent users entering a new phone number during different actions that may trigger MFA. This is done by setting the property "ManualPhoneNumberEntryAllowed" from true to false.

Take into account if you require MFA to an account that doesn't have a phone number registered (verified.StrongAuthenticationPhoneNumber, or Phone in "Authentication contact info" (Users and groups blade)) then you B2C will throw an error saying that there is no phone registered for MFA, and manual registration is disabled.

This is useful in cases where manual registration of phone numbers is a requirement.

The PhoneFactor claim provider can be found in the policies that are part of the B2C custom policies starter pack, inside those that are related to MFA.
