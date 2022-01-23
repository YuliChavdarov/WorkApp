import * as React from 'react';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';

import PersonIcon from '@mui/icons-material/Person';
import FactCheckIcon from '@mui/icons-material/FactCheck';
import PaidIcon from '@mui/icons-material/Paid';

export default function Welcome() {
    return (
        <>
            <Typography variant="h6" gutterBottom fontSize={28} fontWeight="bold" mb={2}>
                Ready for your next big opportunity?
            </Typography>
            <Grid container>
                <Grid item xs={12} sx={{ borderBottom: "1px solid grey" }}>
                    <Typography color="text.secondary" sx={{ my: 4 }}>
                        <PersonIcon sx={{ mr: 2 }} />
                        Build a profile to show the world what you can do
                    </Typography>
                </Grid>
                <Grid item xs={12} sx={{ borderBottom: "1px solid grey" }}>
                    <Typography color="text.secondary" sx={{ my: 4 }}>
                        <FactCheckIcon sx={{ mr: 2 }} />
                        Apply for open roles or list services for clients to buy
                    </Typography>
                </Grid>
                <Grid item xs={12} sx={{ borderBottom: "1px solid grey" }}>
                    <Typography color="text.secondary" sx={{ my: 4 }}>
                        <PaidIcon sx={{ mr: 2 }} />
                        Get paid safely and know we're there to help
                    </Typography>
                </Grid>
            </Grid>
        </>
    );
}