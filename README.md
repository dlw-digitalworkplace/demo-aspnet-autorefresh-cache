# Demo: auto refresh cache with Hosted Service

This project is a demo to show automatic refreshing of memory cache using Hosted Services.

## What it does

The project has an API endpoint /data which returns the _cached_ time. The cache has a duration of **1 minute**.

However: there is a **hosted service** running which updates the cache **every 10 seconds**.

This shows that a background service can update cache values on a scheduled basis. This allows the API calls to never have the need to fetch expired cache data itself, but can always rely on automatic refreshing in the background.