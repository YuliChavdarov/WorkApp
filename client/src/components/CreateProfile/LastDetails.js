import * as React from 'react';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import CountrySelect from '../CountrySelect';
import CreateProfileContext from '../../contexts/CreateProfileContext';

export default function LastDetails() {

    const { infoState, addToState } = React.useContext(CreateProfileContext);

    const handleInfoInput = (e) => {
        addToState(e.target.id, e.target.value);
    }

    return (
        <Grid container spacing={3}>
            <Grid item xs={12} md={6} >
                <CountrySelect onBlur={handleInfoInput} />
            </Grid>

            <Grid item xs={12} md={6} >
                <TextField
                    required
                    id="city"
                    label="City"
                    fullWidth
                    variant="standard"
                    defaultValue={infoState.city}
                    onBlur={handleInfoInput}
                />
            </Grid>

            <Grid item xs={12} >
                <TextField
                    id="address"
                    label="Street Address"
                    fullWidth
                    variant="standard"
                    defaultValue={infoState.address}
                    onBlur={handleInfoInput}
                />
            </Grid>

            <Grid item xs={12} >
                <TextField
                    id="phone"
                    label="Phone Number"
                    fullWidth
                    variant="standard"
                    defaultValue={infoState.phone}
                    onBlur={handleInfoInput}
                />
            </Grid>
        </Grid>
    );
}