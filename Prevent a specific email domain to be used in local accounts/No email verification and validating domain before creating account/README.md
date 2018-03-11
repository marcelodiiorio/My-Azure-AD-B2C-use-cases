In this case, we use Azure Functions to validate the string entered as email address, before writing to AAD B2C.

In this scenario, email verification is disabled, so no verification codes are being sent before allowing the user to continue with the sign-up process.

In order to disable email verification, comment
```xml
<!-- <OutputClaim ClaimTypeReferenceId="email" PartnerClaimType="Verified.Email" Required="true" /> -->
```
and replace it with 
```xml
<OutputClaim ClaimTypeReferenceId="email" Required="true" />
```
The sample base policy has email verification enabled, in order to avoid SPAM on my tenant.
