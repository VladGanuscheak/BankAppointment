import React from "react";
import { QueryClient, QueryClientProvider } from "react-query";
import "./App.css";
import Dashboard from "./Dashboard";
import { defaultConfig, ApiContext, createApi } from "./api";

const api = createApi(defaultConfig);
const queryClient = new QueryClient();

function App() {
  return (
    <ApiContext.Provider value={{ api }}>
      <QueryClientProvider client={queryClient}>
        <Dashboard />
      </QueryClientProvider>
    </ApiContext.Provider>
  );
}

export default App;
