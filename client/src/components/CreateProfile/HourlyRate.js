import * as React from 'react';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import InputAdornment from '@mui/material/InputAdornment';
import CreateProfileContext from '../../contexts/CreateProfileContext';

export default function HourlyRate() {

    const { infoState, addToState } = React.useContext(CreateProfileContext);

    const handleInfoInput = (e) => {
        addToState(e.target.id, e.target.value);
    }

    return (
        <Grid container spacing={3}>
            <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Now let's set your hourly rate
                </Typography>
                <Typography color="text.secondary">
                    Clients will see it on your profile and in search results. You can adjust your rate when submitting a proposal
                </Typography>
                <Grid item xs={12} sx={{ ml: 2 }}>
                    <Typography sx={{ mt: 2 }}>
                        Hourly Rate
                    </Typography>
                    <Typography color="text.secondary">
                        Total amount clients will see
                    </Typography>
                    <TextField
                        required
                        InputProps={{
                            startAdornment: <InputAdornment position="start">$</InputAdornment>,
                        }}
                        id="hourlyRate"
                        label="Hourly Rate"
                        fullWidth
                        variant="standard"
                        defaultValue={infoState.hourlyRate}
                        onChange={handleInfoInput}
                    />
                </Grid>
                <Grid item xs={12} sx={{ ml: 2 }}>
                    <Typography sx={{ mt: 2 }}>
                        WorkApp Service Fee
                    </Typography>
                    <Typography color="text.secondary">
                        The WorkApp Service Fee is 20% when you begin a contract with a new client.
                        Once you bill over $500 with your client, the fee will be 10%
                    </Typography>
                    <TextField
                        required
                        InputProps={{
                            startAdornment: <InputAdornment position="start">$</InputAdornment>,
                        }}
                        id="hourlyRate"
                        label="Service Fee"
                        disabled
                        value = {0.2 * infoState.hourlyRate}
                        fullWidth
                        variant="standard"
                    />
                </Grid>
                <Grid item xs={12} sx={{ ml: 2 }}>
                    <Typography sx={{ mt: 2 }}>
                        You'll recieve
                    </Typography>
                    <Typography color="text.secondary">
                        The estimated amount you'll recieve after service fees
                    </Typography>
                    <TextField
                        required
                        InputProps={{
                            startAdornment: <InputAdornment position="start">$</InputAdornment>,
                        }}
                        id="hourlyRate"
                        label="You'll recieve"
                        disabled
                        value={0.8 * infoState.hourlyRate}
                        fullWidth
                        variant="standard"
                    />
                </Grid>
            </Grid>
        </Grid>
    );
}