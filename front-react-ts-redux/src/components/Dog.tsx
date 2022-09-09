import React from "react";

/**
 * Renders information about the user obtained from MS Graph
 * @param props 
 */
export const DogData = (props:  
    { Id:  number ; 
        Name: string | null | undefined; 
        Weight: number | null | undefined; 
        Breed: string   | null | undefined; }) => {
    console.log(props);

    return (
        <div id="profile-div">
            <p><strong>ID: </strong> {props.Id}</p>
            <p><strong>Name: </strong> {props.Name}</p>
            <p><strong>Weight: </strong> {props.Weight}</p>
            <p><strong>Breed: </strong> {props.Breed}</p>
        </div>
    );
};