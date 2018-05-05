PS C:\Users\mdiiorio.CONTOSO> Get-AdfsClaimsProviderTrust -Name "b2c WS-Fed"


AllowCreate                              : True
AutoUpdateEnabled                        : True
SupportsMFA                              : False
WSFedEndpoint                            : https://login.microsoftonline.com/te/mdiioriob2c.onmicrosoft.com/B2C_1A_SignInWsFed/WSFed/SSO/LOGIN
ClaimsOffered                            : {, , , ...}
ConflictWithPublishedPolicy              : False
CustomMFAUri                             :
EncryptionCertificate                    :
EncryptionCertificateRevocationCheck     : CheckChainExcludeRoot
SigningCertificateRevocationCheck        : CheckChainExcludeRoot
LastMonitoredTime                        : 5/3/2018 11:12:44 AM
LastPublishedPolicyCheckSuccessful       : True
LastUpdateTime                           : 5/2/2018 3:58:32 PM
MetadataUrl                              : https://login.microsoftonline.com/te/mdiioriob2c.onmicrosoft.com/b2c_1A_SignInWsFed/wsfed/metadata
MonitoringEnabled                        : True
OrganizationInfo                         :
RequiredNameIdFormat                     :
EncryptedNameIdRequired                  : False
SignedSamlRequestsRequired               : False
SamlAuthenticationRequestIndex           : 0
SamlAuthenticationRequestParameters      : None
SamlAuthenticationRequestProtocolBinding :
SamlEndpoints                            : {Microsoft.IdentityServer.Management.Resources.SamlEndpoint}
SignatureAlgorithm                       : http://www.w3.org/2001/04/xmldsig-more#rsa-sha256
TokenSigningCertificates                 : {[Subject]
                                             CN=*.marcelodiiorio.com, O=Marcelo di Iorio, L=Madrid, C=ES

                                           [Issuer]
                                             CN=DigiCert SHA2 Secure Server CA, O=DigiCert Inc, C=US

                                           [Serial Number]
                                             09A453996D50BF8D25E2FC7764659DBF

                                           [Not Before]
                                             6/24/2017 12:00:00 AM

                                           [Not After]
                                             7/5/2018 12:00:00 PM

                                           [Thumbprint]
                                             E6A9490AB1BDAAE12EBB341337890E4A74D06B91
                                           }
AlternateLoginID                         :
LookupForests                            : {}
PromptLoginFederation                    : FallbackToProtocolSpecificParameters
PromptLoginFallbackAuthenticationType    :
AuthorityGroupId                         :
AnchorClaimType                          :
IdentifierType                           : http://schemas.microsoft.com/ws/2009/12/identityserver/principaltypes/certificate
Identities                               : {The content of this property was deleted}
AcceptanceTransformRules                 : @RuleName = "CR B2C"
                                           c:[]
                                            => issue(claim = c);


OrganizationalAccountSuffix              : {}
Enabled                                  : True
IsLocal                                  : False
Identifier                               : https://login.microsoftonline.com/te/mdiioriob2c.onmicrosoft.com/B2C_1A_SignInWsFed
Name                                     : B2C WS-Fed
Notes                                    :
ProtocolProfile                          : WsFed-SAML