The objective of this use case is to prevent users to sign-up or sign-in through local accounts using email accounts when there is a corresponding IdP available for that purpose.

Example:

1. User A tries to sign-in using a Hotmail account:
	The SignInName claim is sent to an Azure Function through a REST API in the extensions policy, and evaluated taking into account the domain.
	
2. User B tries to sign-up using an Outlook account:
	The email claim is sent to an Azure Function through a REST API in the extensions policy, and evaluated taking into account the domain.
	
If for some reason there is a match, then a message is displayed to the user, suggesting to use the existing IdP to sign-up or sign-in. If there is no match, then:

	- If it's sign-in and the account doesn't exists, then a standard error message is displayed.
	- If it's sign-up and the account doesn't exists, then it's created following the normal steps.
	
For this use case, we use:

	- A REST API claims provider with two technical profiles, depending on the cases explained above.
	- A base, extensions and relying party policy. The REST API claims provider is in the extensions policy.
	
This can be also accomplished by customizing the RegEx of the email and signInName claims, as explained here https://github.com/marcelodiiorio/My-Azure-AD-B2C-use-cases/tree/master/Prevent%20a%20specific%20email%20domain%20to%20be%20used%20in%20local%20accounts/Using%20the%20email%20claim%20RegEx

In case of the signInName claim, you have to add a specific RegEx. Take into account that this claim can contain usernames or emails. Consider that at the time of creating the RegEx.

At the time of creating this use case, It's not possible to apply REST API validations during sign-up before confirming the email account provided with the code sent to that email. The desired scenario would be to validate the email provided before having to complete the sign-up form. As it was said above, this can be accomplished using a custom RegEx.
