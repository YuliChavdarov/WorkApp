import * as React from 'react';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';

export default function AboutYou() {
    return (
        <Grid container spacing={3}>
            <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Add a title to tell the world what you do
                </Typography>
                <Typography color="text.secondary">
                    It's the very first thing clients see, so make it count
                </Typography>
                <TextField
                    required
                    id="title"
                    label="Title"
                    fullWidth
                    variant="standard"
                />
            </Grid>

            <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Your skills
                </Typography>
                <Typography color="text.secondary">
                    Show your clients what you can offer
                </Typography>
                <TextField
                    required
                    id="skills"
                    label="Skills"
                    fullWidth
                    variant="standard"
                />
            </Grid>

            <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Write a bio
                </Typography>
                <Typography color="text.secondary">
                    Tell the world about yourself. You can always edit it later
                </Typography>
                <TextField
                    multiline
                    required
                    minRows={4}
                    defaultValue='Describe your top skills, experiences and interests.'
                    placeholder='Describe your top skills, experiences and interests.'
                    id="description"
                    label="Bio"
                    fullWidth
                    variant="standard"
                />
            </Grid>
        </Grid>
    );
}