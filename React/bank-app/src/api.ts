import { createContext, useContext } from "react"
import { Bank } from "./models"

export interface ApiConfig {
    base: string;
}

export const defaultConfig: ApiConfig = {
    base: "https://localhost:5001/api"
}

export const createApi = ({ base }: ApiConfig) => {
    return {
        getBanks(): Promise<Bank[]> {
            return fetch(`${base}/Banks`).then(res => res.json()).then(r => r.banks)
        }
    }
}

export const ApiContext = createContext({ api: createApi(defaultConfig) });

export const useApi = () => useContext(ApiContext);
