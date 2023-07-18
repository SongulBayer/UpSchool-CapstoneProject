import React, {createContext} from "react";
import {LocalUser} from "../types/AuthTypes.ts";



export type AppUserContextType = {
    appUser:LocalUser | undefined,
    setAppUser:React.Dispatch<React.SetStateAction<LocalUser | undefined>>,
}

export const AppUserContext = createContext<AppUserContextType>({
    appUser:undefined,
    // eslint-disable-next-line @typescript-eslint/no-empty-function
    setAppUser: () => {},
});

