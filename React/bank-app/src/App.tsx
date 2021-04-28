import { QueryClient, QueryClientProvider } from "react-query";
import "./App.css";
import Dashboard from "./Dashboard";
import { defaultConfig, ApiContext, createApi } from "./api";
import { SettingsProvider } from "./settings-store";
import { BrowserRouter as Router } from "react-router-dom";
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
import DateFnsUtils from "@date-io/date-fns";

const api = createApi(defaultConfig);
const queryClient = new QueryClient();

function App() {
  return (
    <ApiContext.Provider value={{ api }}>
      <SettingsProvider>
        <QueryClientProvider client={queryClient}>
          <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <Router>
              <Dashboard />
            </Router>
          </MuiPickersUtilsProvider>
        </QueryClientProvider>
      </SettingsProvider>
    </ApiContext.Provider>
  );
}

export default App;
