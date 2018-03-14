<Under construction>

The objective of this use case is to cover the scenario where a user that is associated to an available IdP other than local accounts, tries to sign-up or sign-in using local accounts (i.e using MSA/GMail) when those are available as additional IdPs.

Sign-up:

	- We read the email domain provided and look for a registered IdP. If there is no match, then we can consider this as a regular sign-up using local accounts. In that case, we continue with the normal sign-up process.
	
Sign-in:

	- We read the email domain provided and look for a registered IdP. If there is a match, I have two options in mind:
		- Show a message saying the user must use the corresponding IdP.
		- Redirect the user to the corresponding IdP page using domain_hint.
		
	- If there is no match, we can consider this a new account in the directory, and continue following the normal user journey steps.
	
We can create a simple Azure Function and send the email claim.

This is under construction.