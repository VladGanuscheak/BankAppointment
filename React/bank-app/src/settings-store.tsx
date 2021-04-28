import React, { createContext, FC, useContext, useState } from "react";

export interface Settings {
  userId: string;
}

export interface SettingsContextValue {
  settings: Settings;
  setSettings: (_: Settings) => void;
}

const SettingsContext = createContext<SettingsContextValue | undefined>(
  undefined
);

export const useSettings = () => {
  const ctx = useContext(SettingsContext);
  if (!ctx) throw new Error("bad ctx value");

  return ctx;
};

export const SettingsProvider: FC = ({ children }) => {
  const [settings, setSettings] = useState({
    userId: "",
  });

  return (
    <SettingsContext.Provider value={{ settings, setSettings }}>
      {children}
    </SettingsContext.Provider>
  );
};
