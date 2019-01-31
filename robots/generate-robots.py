import uuid
from robohash import Robohash

# generate 24 robots (one to be used for each team)
for i in range(1, 51):
    hash = str(uuid.uuid4())
    rh = Robohash(hash)
    rh.assemble(roboset='set1', sizex=80, sizey=80)

    filename = 'robots/robot-{}.png'.format(i)
    print(filename)
    with open(filename, "wb") as f:
        rh.img.save(f, format="png")
