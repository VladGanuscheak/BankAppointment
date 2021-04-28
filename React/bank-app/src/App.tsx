import React from "react";
import { QueryClient, QueryClientProvider } from "react-query";
import "./App.css";
import Dashboard from "./Dashboard";
import { defaultConfig, ApiContext, createApi } from "./api";
import { SettingsProvider } from "./settings-store";
import { BrowserRouter as Router } from "react-router-dom";

const api = createApi(defaultConfig);
const queryClient = new QueryClient();

function App() {
  return (
    <ApiContext.Provider value={{ api }}>
      <SettingsProvider>
        <QueryClientProvider client={queryClient}>
          <Router>
            <Dashboard />
          </Router>
        </QueryClientProvider>
      </SettingsProvider>
    </ApiContext.Provider>
  );
}

export default App;
