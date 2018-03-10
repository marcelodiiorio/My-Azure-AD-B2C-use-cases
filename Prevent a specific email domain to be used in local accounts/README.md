<Under construction>

In this case, we use the existing RegEx in the email claim to modify it in a way it denies using certain domains in local accounts.

Original Claim type:

	  <ClaimType Id="email">
        <DisplayName>Email Address</DisplayName>
        <DataType>string</DataType>
        <DefaultPartnerClaimTypes>
          <Protocol Name="OpenIdConnect" PartnerClaimType="email" />
          <Protocol Name="WsFed" PartnerClaimType="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/email" />
        </DefaultPartnerClaimTypes>
        <UserHelpText>Email address that can be used to contact you.</UserHelpText>
        <UserInputType>TextBox</UserInputType>
        <Restriction>
          <Pattern RegularExpression="^[a-zA-Z0-9.!#$%&amp;'^_`{}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" HelpText="Please enter a valid email address." />
        </Restriction>
      </ClaimType>
	  
The modified regular expression doesn't allow accounts with the domain "hacker.com". The claim definition is in the base policy. claims schema section.

I'm in the process of creating an alternate version of this use case, where we use Azure Functions to validate the email entered during sign-up, and before sending the verification code.