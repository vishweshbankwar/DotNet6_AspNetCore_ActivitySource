# DotNet6_AspNetCore_ActivitySource
.Net6.0 - AspNetCore ActivitySource

Run the app and make request to https://localhost:5001/WeatherForecast with `traceparent` header set as 00-35aae61e3e99044eb5ea5007f2cd159b-40a8bd87c078cb4c-00 to observer the behavior.

sample output

Activity Started:
ParentId: 00-35aae61e3e99044eb5ea5007f2cd159b-40a8bd87c078cb4c-00
ParentSpanId:40a8bd87c078cb4c
Activity TraceId: 58d31e8033271f2a4de778ba62e99e7d
Activity Stopped
