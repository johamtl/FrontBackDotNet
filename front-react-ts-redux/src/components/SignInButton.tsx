import React from "react";
import { useMsal } from "@azure/msal-react";
import { myapiLoginRequest} from "../oauthConfigAzure";
import DropdownButton from "react-bootstrap/DropdownButton";
import Dropdown from "react-bootstrap/esm/Dropdown";

/**
 * Renders a drop down button with child buttons for logging in with a popup or redirect
 */
export const SignInButton = () => {
    const { instance } = useMsal();

    const handleLogin = (loginType: string) => {
        if (loginType === "popup") {
            instance.loginPopup(myapiLoginRequest).catch((e: any) => {
                console.log(e);
            });
        } else if (loginType === "redirect") {
            instance.loginRedirect(myapiLoginRequest).catch((e: any) => {
                console.log(e);
            });
        }
    }
    return (
        <DropdownButton variant="secondary" className="ml-auto" drop="left" title="Sign In">
            <Dropdown.Item as="button" onClick={() => handleLogin("popup")}>Sign in using Popup</Dropdown.Item>
            <Dropdown.Item as="button" onClick={() => handleLogin("redirect")}>Sign in using Redirect</Dropdown.Item>
        </DropdownButton>
    )
}