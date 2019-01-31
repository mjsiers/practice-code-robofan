# RoboFan
## Robot Image Generation

This python utility will generate some random robot images.  These static images
are then copied into the RoboFan.Web/wwwroot/images/robots directory. This project
is using the [**RoboHash**](https://robohash.org/) utility and the source code for this
utility is available on [**GitHub**](https://github.com/e1ven/Robohash).

When a new robot is generated in the RoboFan applcation, the new robot will have a 
randomly selected robot image assigned to them.  The robot images for each fan are 
loaded into the database and not served as a static resource.

## Installation Procedure (using Anaconda Python)
```conda create --name robots pip python=3.6```
```conda activate robots```
```pip install -r requirements.txt```

## Generate Robot Images
```python ./generate-robots.py```
