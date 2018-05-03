This scenario allows you to use ADFS as WS-Fed IdP.

You can configure pretty much everything by following this document https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-custom-setup-adfs2016-idp, which explains how to configure ADFS as a SAML IdP.

Things to consider:

- We are using WS-Fed, so the SubjectNamingInfo claim must be in the format namespace/name. An easy fix for this is to edit the claims rule on the ADFS side, to configure the User-Principal-Name claim 
in the following way:

LDAP Attribute = User-Principal-Name.
Outgoing claim = http://schemas.microsoft.com/identity/claims/userPrincipalName

Additional details to configure the relying party:

Relying Party identifier: https://login.microsoftonline.com/te/mdiioriob2c.onmicrosoft.com/B2C_1A_TrustFrameworkBase-ADFS-WSFED-IdP, which must be your base policy.
Endpoints:
	Type: WS-Federation.
	Trusted URL: https://login.microsoftonline.com/te/mdiioriob2c.onmicrosoft.com/B2C_1A_TrustFrameworkBase-ADFS-WSFED-IdP
	
Certificate: See link above for details.
	
The policy files contains additional comments and instructions.
