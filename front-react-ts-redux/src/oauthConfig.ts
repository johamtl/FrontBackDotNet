//Authorization URL
//const authEndpoint = 'https://login.microsoftonline.com/c6311f20-f2d8-48d7-a2b6-12af7bdafd5f/oauth2/v2.0/token';
const authEndpoint = 'https://accounts.spotify.com/authorize';

const scopes = [
    'user-read-private',
   // 'user_impersonation', //Azure
];

export const getAuthorizeHref = (): string => {
    const clientId = process.env.REACT_APP_SPOTIFY_CLIENT_ID;
    const redirectUri = process.env.REACT_APP_REDIRECT_URI;
    const scope=process.env.REACT_APP_SCOPE;
   //const clientsecret=process.env.REACT_APP_CLIENT_SECRET;
   // const resource=process.env.REACT_APP_RESOURCE;
    
   // return `${authEndpoint}?client_id=${clientId}&client_secret=${clientsecret}&scope=${scope}&response_type=token`;
   return `${authEndpoint}?client_id=${clientId}&redirect_uri=${redirectUri}&scope=${scopes.join("%20")}&response_type=token`;
};