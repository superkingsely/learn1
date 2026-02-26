

git config --global user.name "superkingsely" 
git config --global user.email "superkingsely@gmail.com"

###################################
private_key.pem
public_key.pem

openssl rsa -in private_key.pem -pubout -out derived_public.pem

diff public_key.pem derived_public.pem

If nothing prints → ✅ They match
If differences → ❌ You are signing with wrong private key