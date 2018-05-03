PS C:\Users\mdiiorio.CONTOSO> Get-AdfsRelyingPartyTrust -Name "sample claims aware application"


AllowedAuthenticationClassReferences : {}
EncryptionCertificateRevocationCheck : None
PublishedThroughProxy                : False
SigningCertificateRevocationCheck    : None
WSFedEndpoint                        : https://app1.marcelodiiorio.com/sampapp/
AdditionalWSFedEndpoint              : {}
ClaimsProviderName                   : {Active Directory, B2C WS-Fed, B2C SAML2}
ClaimsAccepted                       : {}
EncryptClaims                        : True
Enabled                              : True
EncryptionCertificate                :
Identifier                           : {https://app1.marcelodiiorio.com/sampapp/}
NotBeforeSkew                        : 0
EnableJWT                            : False
AlwaysRequireAuthentication          : False
Notes                                :
OrganizationInfo                     :
ObjectIdentifier                     : a41d5e02-8e9f-e611-a944-000d3a263ec8
ProxyEndpointMappings                : {}
ProxyTrustedEndpoints                : {}
ProtocolProfile                      : WsFed-SAML
RequestSigningCertificate            : {}
EncryptedNameIdRequired              : False
SignedSamlRequestsRequired           : False
SamlEndpoints                        : {}
SamlResponseSignature                : AssertionOnly
SignatureAlgorithm                   : http://www.w3.org/2001/04/xmldsig-more#rsa-sha256
TokenLifetime                        : 0
AllowedClientTypes                   : Public, Confidential
IssueOAuthRefreshTokensTo            : AllDevices
RefreshTokenProtectionEnabled        : True
RequestMFAFromClaimsProviders        : False
ScopeGroupId                         :
Name                                 : Sample Claims Aware Application
AutoUpdateEnabled                    : False
MonitoringEnabled                    : False
MetadataUrl                          : https://app1.marcelodiiorio.com/sampapp/federationmetadata/2007-06/federationmetadata.xml
ConflictWithPublishedPolicy          : False
IssuanceAuthorizationRules           :
IssuanceTransformRules               : @RuleName = "Pass All Claims"
                                       c:[]
                                        => issue(claim = c);


DelegationAuthorizationRules         :
LastPublishedPolicyCheckSuccessful   : True
LastUpdateTime                       : 3/8/2018 2:05:09 PM
LastMonitoredTime                    : 3/8/2018 2:05:09 PM
ImpersonationAuthorizationRules      :
AdditionalAuthenticationRules        :
AccessControlPolicyName              : Permit everyone
AccessControlPolicyParameters        :
ResultantPolicy                      : RequireFreshAuthentication:False
                                       IssuanceAuthorizationRules:
                                       {
                                         Permit everyone
                                       }