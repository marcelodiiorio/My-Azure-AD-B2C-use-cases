 This scenario allows you to use Azure AD B2C as SAML tokens issuer.

What you need for this scenario:

	- An ADFS farm with accessible metadata from internet, and access to https://<YourFarm>/adfs/ls/idpinitiatedsignon.aspx, or a sample federated web application.
		- Add your B2C tenant as Claims Provider Trust in ADFS.
			- You can create it using the B2C metadata URL available for this purpose https://login.microsoftonline.com/te/<YourB2CTenant.onmicrosoft.com/b2c_1A_<YourB2CRPPolicyName>/samlp/metadata
		- Create a custom claims rule like this one:
		
			c:[]
			=> issue(claim = c);
		
	- The three sample policies provided in this case. You can have less policies if you want, as long as you put all the elements needed in the right place.
	- The extensions policy file only contains the user journey called from the relying party policy. You must take this and add to your own policies, and apply additional customizations, as needed. The same principle applies for the base policy.
	
It is suggested to use the B2C starter pack, available here https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#download-starter-pack-and-modify-policies

How to test:

Access to https://YourADFSFarm/adfs/ls/idpInitiatedSignOn.aspx, or the url of your internal application published through Web Application Proxy. Select your B2C tenant for signing-in, and enter credentials of a B2C tenant user. If you get an error, you can troubleshoot by checking the ADFS log, or use Application Insights (https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-troubleshoot-custom).

Remember that if you do any change on the B2C side that may change the information provided through the metadata URL, you must trigger an update of the claims provider trust in ADFS, if you are using metadata to pull the different parameters from B2C.

The sample claims-aware application is available here https://blogs.technet.microsoft.com/tangent_thoughts/2015/02/20/install-and-configure-a-simple-net-4-5-sample-federated-application-samapp/

An export of the relying party trust is available as part of the files of this use case. One important thing to take into account, is that you must configure the ClaimsProviderName property, to add the B2C SAML issuer so it appear as available for signing-in. For this, you must run:

Set-AdfsRelyingPartyTrust -TargetName "<Name of your test app>" -ClaimsProviderName @("Active Directory","B2C SAML2")

Where B2C SAML2 is the name of the Claims Provider Trusts you have previously added. If you want to add more claims providers, just add ", <CPT name>" to the command above. If you don't append to existing content, you will remove all the CPTs, leaving only the new one.

The web.config file is provided as part of this use case, as well as an export of the claims provider trust settings.
	
