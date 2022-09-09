import { myapiConfig } from "./oauthConfigAzure";

/**
 * Attaches a given access token to a MS Graph API call. Returns information about the user
 * @param accessToken 
 */
export async function callMyApi(accessToken: string) {
    const headers = new Headers();
    const bearer = `Bearer ${accessToken}`;

    headers.append("Authorization", bearer);
   // headers.append("client_id","c7919097-f8f2-4202-8573-5727fd068497" );

    const options = {
        method: "GET",
        headers: headers,
    };

    return fetch(`https://localhost:44319/api/dog`, options)
        .then(response => response.json())
        .catch(error => console.log(error));
}



