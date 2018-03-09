This scenario allows you to use Azure AD B2C as WS-Fed tokens issuer.

What you need for this scenario:

	- An ADFS farm with accessible metadata from internet, and access to https://<YourFarm>/adfs/ls/idpinitiatedsignon.aspx, or a sample federated web application. I'm personally using the sample application described here https://blogs.technet.microsoft.com/tangent_thoughts/2015/02/20/install-and-configure-a-simple-net-4-5-sample-federated-application-samapp/. It's a simple application that shows you the content of the issued token after being authenticated. This is a WS-Fed application that won't work with SAML. For SAML, you can just try to sign-in to the idpinitiatedsignin.aspx page, or federate another web application.
		- Add your B2C tenant as Claims Provider Trust in ADFS.
			- You can create it using the B2C metadata URL available for this purpose https://login.microsoftonline.com/te/<YourB2CTenant.onmicrosoft.com/b2c_1A_<YourB2CRPPolicyName>/samlp/metadata
		- Create a custom claims rule like this one:
		
			c:[]
			=> issue(claim = c);
		
	- The three sample policies provided in this case. You can have less policies if you want, as long as you put all the elements needed in the right place.
	- The extensions policy file only contains the user journey called from the relying party policy. You must take this and add to your own policies, and apply additional customizations, as needed. The same principle applies for the base policy.
	
It is suggested to use the B2C starter pack, available here https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#download-starter-pack-and-modify-policies

How to test:

Access to https://<YourADFSFarm>/adfs/ls/idpInitiatedSignOn.aspx, or the url of your internal application published through Web Application Proxy. Select your B2C tenant for signing-in, and enter credentials of a B2C tenant user. If you get an error, you can troubleshoot by checking the ADFS log, or use Application Insights (https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-troubleshoot-custom).

Remember that if you do any change on the B2C side that may change the information provided through the metadata URL, you must trigger an update of the claims provider trust in ADFS, if you are using metadata to pull the different parameters from B2C.

Note: If you want to have both SAML and WS-Fed in the same claims provider trust, you need to configure it manually, because the metadata URLs from B2C will configure it with the SAML or WS-Fed respectively, and not both. Metadata URLs are:

	- SAML: https://login.microsoftonline.com/te/<YourB2CTenant>.onmicrosoft.com/b2c_1A_<YourSAMLRPolicy>/samlp/metadata
	- WS-Fed: https://login.microsoftonline.com/te/<YourB2CTenant>.onmicrosoft.com/b2c_1A_<YourRPWsFedPolicy>/wsfed/metadata
	
You must also add an additional protocol name entry in the claims schema AT LEAST for each claim you are outputting in the relying party policy. See the example below.

        <DefaultPartnerClaimTypes>
          <Protocol Name="OAuth2" PartnerClaimType="upn" />
          <Protocol Name="OpenIdConnect" PartnerClaimType="upn" />
          <Protocol Name="SAML2" PartnerClaimType="http://schemas.microsoft.com/identity/claims/userprincipalname" />
	  <Protocol Name="WsFed" PartnerClaimType="http://schemas.microsoft.com/identity/claims/userPrincipalName" />
        </DefaultPartnerClaimTypes>
