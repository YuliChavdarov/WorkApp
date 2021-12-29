import * as React from 'react';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';

export default function LastDetails() {
    return (
        <Grid container spacing={3}>
            <Grid item xs={12} md={6} >
                <TextField
                    required
                    id="country"
                    label="Country"
                    fullWidth
                    variant="standard"
                />
            </Grid>

            <Grid item xs={12} md={6} >
                <TextField
                    required
                    id="city"
                    label="City"
                    fullWidth
                    variant="standard"
                />
            </Grid>

            <Grid item xs={12} >
                <TextField
                    required
                    id="address"
                    label="Street Address"
                    fullWidth
                    variant="standard"
                />
            </Grid>

            <Grid item xs={12} >
                <TextField
                    id="phone"
                    label="Phone Number"
                    fullWidth
                    variant="standard"
                />
            </Grid>
        </Grid>
    );
}