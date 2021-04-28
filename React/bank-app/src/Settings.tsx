import { Paper, TextField } from "@material-ui/core";
import { useSettings } from "./settings-store";

export default () => {
  const { settings, setSettings } = useSettings();

  return (
    <Paper>
      <TextField
        value={settings.userId}
        label="User Id"
        onChange={(e) => setSettings({ ...settings, userId: e.target.value })}
      />
    </Paper>
  );
};
