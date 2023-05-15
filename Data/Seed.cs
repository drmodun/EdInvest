using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using Shared.Hash;
using Shared.Models;
using Shared.Models.Items;
using Shared.Models.Users;
using System.Reflection.Metadata;

namespace Data.Entities
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //temporary generated countries without real flags, will add later 
            var countries = new List<Country>
            {
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAADHSURBVCjPhZFBDoIwEEV/peLWlW5ceAcTvY6ncW9i4pm8hgsT2QgGEFLKdygQkKD2Z9pJ5nUyv1XE7zX5U4euD6WGBTatFVZYwhu5GuDKsko2WWhswU9lPB2xxqRqszU24ZMRUyaiiA/eBbk1iAAV/xLlbo8ZMhAglewsiBLgYmUI4wwRJSxyzFsPO916ndazu/ARClhg0drsPKrGkA/bZHrorkKUE8cBuKI3fMkhAkH4/S+IbjI9Vux/jNof4lmBvowL43Lmb/8gdgK2+FpkAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Thailand",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKRSURBVDjLzZHfS5NRGMeFoIsCoX/CEpq6GeWNGypO24/WpuliQ0hf3dyQta3lvGkibthgpF4kFYkI3igKIoleSCmiEDUVf5ZMk4Eazr0nXU3n3n07Z3eL7rrpwBcenuf7fM7znJMFIOtflPV/AFLuJwaqYyrCJLgcRHDYSLLFSi6aTSTBNZDzujpypn9I4lXV5JdKE4nJ7xrTANpQQxXD9BSwsACsrADb28DGBoQP7xEZGkJ0cBAnAwPgX71GuLsb4WcenErLYidFxRoG+IS3b4CJCWBkBFhfB5aXgdFRCC4XwmYz9jkO0YYGHBmN+KxWY6urC9s2O4j4TpgB8lNPHR9Tz30AvQ17e0if2VkI1dXYVyrxXaHAD6qd0lJser3Y4ZpA8m8f8LnimvQb0H2v0X0nhXYPMD4OHBwAS0tIGQyI0EaeQvjKSoR8Puw+4kDyboWiNwoKMn7hwtyUnaivf5dsbQUWF4G1NaTo6KS8HLGKChz5/fhGm/mbhaHo9TzRX7/xzGDMjjyomZp6bEeANvT398NP3+FrZyc2W2zwO5xJlvN6vVGLxeKSSqVXMwASieRylUrV3dPTg8PDQ4RCIfoUs3jh8eCl2SJ82dpKsNz8/DyYR6VS+TMAYrH4ntPpJMHVVbTf1/1U090bGxvR29uLtra2dKxUKpN6vX6SQZj3zwn8HR0dcQZYLiouLJfKkjMzMwgGg5ibm6M/OwqZTHaq0WiuMADzZgBEIlGzyWTiGUCn002XlJQk5HI5tFptWixmOVZjAObNAOTSo1arNwOBAD88PHw8NjaGvr4+2O12uN3udMxyrMY8zJsByMnJuURHLFAoFLscx8WsVmuc6ry2traOqozGJyzHaszDvL8B+W6qBSeP34AAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Philippines",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIfSURBVDjLjZNNSJRRFIafcRJSnGEszTQddQZUJCGTCiGjXLkaiIKgTUhECK6K1oGroE20adEmQnfVIqEYhKRgyiwlFBkcqVzYHzNiVo7f982957QQpxk08cDhcA+c57735R5Uld3kt+5u3a5fwi5jtL9/275PVfOHZDKp1lqMMWxWYwzpdJpEIkFdXR3RaJRYLObbnNlTSMvlckQiEQAKwapKb28vqko8Hi9SUAQwxgAwPr/xMqtgBUQFa6Gv3eC67v8Bnuehqhw9uLKtkRDaHWBiqRJRwciGgko7Tb0dI9hxBcdxdgYAHKvN/LvZOujSY0LhHrJf4jsrcF0XVeXl4j6sKkagMTdKZ/g4wdpO0uM3KfOFiwBF/2DV/kRVOdmQ5lRDmjM1szS4zwhUhbC/nnKg/SLR4Cdmh/tKtwBuTAw0zYXeo6qICCPDwyy8uU9161lwppl8OEJFaJ0afwbjeLEtABFpLin1k1ydRVWpDfymrfkQgcos4n4GFeyfdzSfvs6a692ZvNsdyAOuJa4Gsb4X+0urGFt6jtgcLRUfCYWPINkZVNbpOteKeF/ZuzdFuONC/XfP3MoDrLEDrufpQnqeteUsM2/v0dTWQ3kgg5pl8PmZepICBHFSVLc0UuZ4l18NHW73qSqDg4NaaOb5yAwnLj3AX7KImhVAi3z3l7XyY+4DqdGhR0XLtBmvb3dl1Eq5iqIiBan5igiqOvUX9fhxNiezxvQAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Ecuador",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAEoSURBVDjLrZMxSgRBEEXfiBiIkRjpRTyAuZGH8ALewmtsbOAVNjM1F0FEwURwZ9vq+t+gZ3aR3RFEC5qGLv6v11XdnW3+ErsAs9nMpRT6vme5XLJYLDZW3/erfCmF+XzeAXT/QgBwc7ewASUYsOHidL+7vn1eVzCkzNX5cbdhkIKjgx0EWPDyrpXu5HAP2Ujw+LrcTmBDuu0y1LV+JVaaSG83qAnS2iBzPDdZQTKZIsqEgQYC6TtBraKmUJoqUaL+TNAMjLI5RIhaW/VMTxNUtUbKbgTDFT7DK4pMU8bExhRSpLp1DzwaJFFFDhQRUwSGp7ckh4mM7ytKUqNVrzIREwSXZwfdtpdWwsRQXWpT2WowFRHZxNl6I+l3BvXT3D98bAjH+PNn+gIL+yQjrYYUIQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Dominican Republic",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAADqSURBVDjLY/j//z8DJZiBKgbkzH9cMHXX6wcgmiwDQJq3nv/4H0SD+OXl5dlA/L+kpOR/QUHB/+zs7P+pqan/ExIS/kdGRv4PDg7+T10XDHwgpsx8VNC56eWDkJ675Hmhbf3zB0uPvP1fuvQpOBDj4uKyIyIi/gcGBv738vL67+zs/N/Gxua/iYnJf11d3f9qamqogRjQcaugZPHjB66V14ZqINrmXyqIn3bvgXXeJfK8ANLcv+3lfxAN4hsZGWVra2v/V1FR+S8nJ/dfXFz8v5CQ0H8eHp7/7Ozs/5mZmVEDEWQzRS6gBAMAYBDQP57x26IAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Philippines",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIESURBVDjLvVO/a9tAFD5ZdWwZg11w2iR1idMhxhm8ZOlS3K1rlwwZRD2EQCd7KIUOpmvoj7E4BBxElw72kMFLh5osBkEp3fwXlMY4TlRJtk4/7kffqW6wcDMFevDxTu/u+/S9d3cS5xzdZMTQDcet6xY6nc7jIAh2AU9830eAz4BP9Xr9dH6f9K8S2u22IL8rFovb6XQaEULQeDxGuq5/A5EXjUbjdMFBt9tdA9I+YAewWiqVbieTSWRZVigg5uVyebvf7+/C9kUBUN7P5/OvM5kMopQiz/OQYRhoZj/MpVIpkd+r1WoJyB02m019XmBH2J1OpwhjfEUEN1fRtm1UqVRipmk+6/V6ghYRCCHIruuGfxQk4URE8S3WJ5MJyuVyYv40coywsT0cDv+cbSyGHMcJhRRFCcEYQ5IkoWw2i0ajkRA4ifQABI4Gg0FYyszNV4AMeDQr4TtAATwEnEBjDxeOsaadvYnJSGEUYRFdj2PGmTLxOSaEKZ7LMCVccWzy8svBJo6U8Pz458pWPlF1A97aXE1UL2zS2rgbr54bQevBnXj114XfKkDevPQO/pIjDuofz94TymU3YNQnXMYeozRgUAKjxGdyABH6KLsOfaV/2MKRt7B39OPe+nJcPbeIVlheUg0j0AorS6p5GWj31xKqZRJtfSOlAvntPPnaq/xfX+NvE6ltVjnyz4AAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAH3SURBVDjLjZNPaxpRFMXTfo4E+h1S8hmy7bJ0G+i60ECg2QXaIqVaqwttplXCSEMNDlZTqdEaEkyslIo4s9BG4yIOYzIo/v+Xnrz7UofR2DYDh1m8d37v3vPenQMwR2LfPNMi09J/dI/pruEzARZ7vV59OBxejkYjzBJbh8PheGOGmAFLZG61Wmi328jlchBFEYIgIB6PQ9M0DlFVFU6n04CMzXcIQBu63S5qtRp8Ph/K5TKy2SxCoRCq1SoHdDod0CEul+saMg3o9/vI5/MIh8OoVCpwu92QJAmBQACxWGyiJZ7JNIC1gUKhgGAwCEVR4PF4YLfbkUgkYLFYeCUE/ifA7/cjnU7z8lOpFP8nk0lYrVbenq7rswFJpQ7bThFbgUPIsoxoNMqzoCpsNhuHNZtNNBqNm4Anr3btL7dPIR2dY917Aqe4xyvJZDL8RuhkyodCJE0Ann8srW2Ipd+fj3VEfujYimtYea1MBEatEYBE78EAMOPqM2+pLx1dIPxdx6cDqqCID19VbhprMBhwkXkCsCqcdHcOzxE8vsD2fhVr74vwRlXjVLPZLAPw+G2hthmpQPym4em7XxAiZzdKnyUD8PCF/OjBhlxfXv/ZcX85Y/Qh/jYLU7o0QvxzE/dZQG1auI2Z7W3y6TUBFghyi3Eei0Z/4QrVT8W6WBitpQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAADtSURBVBgZBcFBSpVhGAbQ8/18JNEFu1dEW4MbaAFOhDbQPBoE7ag91MhRtYgop9KgIsIfDcQQ3+ftnNEAAACACcCnrzlJ5/zsBQAsAB93fbKzG3kOACwAp+vDbdyrLwDAaJ87ItKHI37eVGUpL7fAJLZaM6Id7bf4DmBSWrtxJ9qiHSgAk/htz8atiAfRNt51KW/G5GzwoZ8oLVpcObDFBSZQIqK1iAgKk/ddHmsRLdpTv6z39SiYlGNtdaS1diVWb/eASWk/PPPHtdg4FAVgocSxuPZqvB6rFgVgUi5FqX9Q+SZ3+QswGgAAAPAfKnCHO1UwyPEAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Poland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALiSURBVDjLhZJdTJtlGIa/hISExGRHO1BjthEiRp1HzHgEo4vGYTAkGwElohkpyIYRyFhZgQIBAorVqtSyCmxpC8Gu42dFkLBVWBijShYYPxJBQYSQEMeQn69rbLl86uaMMN3BffLmve7nen8UQPlXBqzREiMeywgD5gBXTAF6a0foqTLSZojeuX8nnC+gircVxjolbhjtgOt26DeDq0DFmZu/u2DAGk7/uR6GHXDTJZst0F2DTIWOEmjTQacBPB9Dux6+TOvBkhz+T4HHYsIrcKigtzYgoEZ0Ix5Maj4VgU2r2XQkBaebU5nprGK08RXGzM+lC2w+yLefBRhukYnVATrK9tFe9JjoVoruEI7sIWwnKpe6nj6x7NGxdqsLNpa4c8vF8Eev/qbQZzQx2CR6ppCuhnbdk1zM/5mvK6A1F1pOsuVKYXWiZNv/62WW+2tRx9sIzA8ycV77hyK60ww57p3NdTpCdC/iLoemdCfW1LhV56GC1Yni7aA6iPpTDre/e48f7BlMNqSjGl6YUUTXz5DcslOmObLDRFfF/i6cOx432XeqfHX8LEHfDbZm38a3kMb6lJ6FL2JRL2hBH7mmiK6fwUawa0O3G0F9CtQnrdz8JMaw/L3uPpyO75c3+X2iiFmzZt1neOavo1F8YEOR253hUgGiq1KXFI4pIba74vFjU9+cDgbVa/jmMri78BZrYjJjPnJ39sMXowRcpCYmVDCpUP/G+6KbyeeJe0JP1pD9VMZkt56xHhOL3mS25tK4PVrIj3XxK9PGlyIfPG3xgThJsrLzazo/OALr80xbj+PRP8H1+qNcrYzFZjzTsOvb7/rKkgrt8wH/jTr83k/xVsXzVeb+gKW2ZLu6unqztLQ06pEFKYf3BmveeZarNQnBK0bNgFt3MFJgu8AbhYWFbf9b4Ha7X3M6nYs2m61450aBy/Ly8vpzcnJe/s8Cga0Cv/6ws4YicGJWVlaCJOzvtT8B/ZHVkQhA0SkAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJrSURBVDjLpZPPS1RRHMU/982bGUcZLemHkAougmhhIhgqtUqKgggXtWnt0mUg4V9gKNGmwKJFbYMwoxDaRAsXLrQyUlMricSycmbee/e9++79tvBHZNGmLxwOnMXhcDhfJSL8z/m7hcHBwSHgyraxiOzAGMPw8LDq7+8XrTWjo6NK7U4wMDAgvb29LCwsUKlUGBsb4+HNyyRLd7h0rYrm5mbq6+uJoojl5eV3fySoqalhZmaGtrY2amtr6e7u5tmbT0xOnqSvr40gCFhZWSGfzxMEQbM//7hjuqr26FGlPACKxWO0trby6EM9T997QI6TDY20Hz7MxMQEXV1dzM3N0djYiDEm5yvxjjSduJtVSoFA/tUtCoUCTxY9SioPHjz/Ch0NGUqlElproigijmPSNMUnFY1L8vHqTWySIQwN5XIZkRrEA5VRiKdYW1sjDMO/GBjliUuwSQ5xwvr6OqsLk1yrm6ZJ5n/r51wPwH3OnoGR14cQEXyUVLk0Ivi8RrA0xam6iJZMNbnz1/EzWUwSo7UmSRKy2Sz56j0k4xcJwxBjDD7Gwy8cYH/nVfZ3Og5GEVU5w/iDEcTGAGgdYFONtZrs3gu0A1NTUwDjPkZErMaFLxG7gRe+JRHD6RP7EKdRSnDGIdYi1lBo6WHx9g1mZ2fV5hJjRFyKM1+QdAOUj9gKSAoSI+IhNsClZcSWQaldU05EFBZJvyHpj03YDSTd2OIyYkuIDRCncfFHAL1jIIn7nobr1aaSK+KKnkgWXBFk31YHCeJtsvIsVmuRxMW/DHQ8tHSr9zhCD4riP19PAPUiwcm9bUn97zv/BLX9cx0txHrHAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJuSURBVBgZpcH7a05xHMDx9/ecI/OcXWzZRDPCqMlcFqklKZeSwi9spIRcSwrDL5K/QFJLSoTIJX4yJOQ6lkSYjfV4MGwe2549l7Pn+z3nfIz8INlPe72UiDAYFoNkMUgO/WT/njXAEcCmnwQhBAFifMT3EeMj2iDaIMYgWeOHWu90b1w7o8J9u1cCJ9T8BS55+eC6EImAMYSdHXS3f8EKApwwJMhqUl4GuroZfvdBWrRe4wB1qnyyizbQ3g4VFZBOQ1sbNDbiJZPYvk+OCEE2S2cigVtdTd+MSrf43qOjDrBBWpqPE/8+S5WOhdxcKCuDRAKiUWzPwxbBVtA1qZuixaMJXj1mxN2v30SbXfbB+w875HrDJelJVOJ55UopKCgAY+DpU7TnMUQp0mN6yF07m5K5Wwj8J2Hc+7yvtOHlSSUi/OJv3Zwv2j9nFRcvsZcvh7w85PBhemMxsuP7UKvHUThtEenPbfjJkMT7l5mWphcbLf5w6o/1hllda6IfrpkrV/mtsBDH9/GrRlIwdSlB5h05I0bjRGDUvOmRCRVl9UpE+Ju3bEW+aHPJqZq5cMjUKQSxGN+CRgpXzcGyYyhrGBLEwWRoPvsppUSEf6XmLywVbe4wb/LEVHkH5ASSW1WkHKsHZeURGs3b8y19r9/2rlciwv98OFS1V7lDD5SsXBcRfRMVJHnTkEjbyTBlK8Xr1s7tNaeilx0GYFWU1Iysro3oeD2OU0Dz7XTmWVN8x9g+72KOa1Nz6mOSfg4DsGy0stuxhxbz5saP1Ivnnds2nXl/mn84DOBLNH6rN3FnXKYr7bW2fq9bf+LdBf7jJ8/eN9kzWRDgAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJlSURBVDjLlZJJa5RBEIaf7q8nGceJRMkiKCJIEEVUXMYtp+gxKBIQXC4iIjl496IomJuiv0BQD0HBQyCHgCIqxn29CYqKGjWZaGRiJjNfd1d5mJhE8KANzdvVTT1db1Hm8p2xE6ocjiqLRYQoEESIUYiihCizdiQGJYo87jnQVgBwonq0q9DQxH+sk1ferP59dlGkCaDv7UWCBEIMeAn46Gc0hum3Y1t68D7WzwIoAPtWHvqn3ycqAR8iM4AoAPTeHfknwM4NC0hnA8IUAGBvewtXB4fZs611+u7ag2G6Ns/Eo6XKHxWYc/1DeqijmYEXY1gAYzAot18UaaiHchqYn6/j88gkxkI+lyBqGCtNcvP50CYXo6CASwy7C830PSqyq9DCwL2PdBSWs2tdnv4Hnzi+f8UfVi7dKiJiHlofBRVwFvqfFkmSmparnu/jAYDrT4anEysBSlUo/kgxRrA+CKpKJoHO9c1knaFzfTPWGhIFH4Wz3esQUaIoCULOCdVqldJEigtSa2JiDTdejgJw4+Uo2YylUvWcvvIeayBEQabsqioo5DKCDSHUemBhx5omXFLTIEo1BhKbwRiHIcGYBNSiavAhkKYB52PNwqoleb58n2RZ6xzeff3JeNmTMY7uzgaCpIAFBTVC1tVxpvcD30oTuBh18FTv67VplLk+RHyIxCBTfjMIk1x4doSm3BIMlmL5I4c3nseSpVxNcWcPrmj/28TtOX1fly6E1vw429cUaKxbBBZ+VBbRMjeQqwNnDEZV/zqyG7qvD7YtnrO1sb6RrJtHEI8RwWhETJlXH94yUvL8AgiPWj6e64RKAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHbSURBVDjLpZM/a1RBFEfPnfciq4uChLgrWChaihBYbAxqBD+AgrGwVBDRxipgH1AMEQJpbawU9SvYCRaiEmOaBUkRDRYBwf3zZt691+K9DWuXxYELwzCce37MXHF3/mfJtYcv789d7jzZ7XvTHTDDzVBT3Bxzw1Uxd1wVNePIgdTb3NxefLuysJZ3LnRWpxrN0GpM1LjZ6+sqsJb3k4f+7p+J1QfJA0Du6izdOjMx4M7jLSqAGwCxVBxwc9TAcMwcNUNLr8qNqM6p9mHUtAJQv4IEQdzxILg4YkIIgkhARJHMySyQl9V9K2vAiBQAFwGBzMEEzJzMIUhGLqDiaKiMTa2OYPU/EAH3f0Ai4OqYgAsQhMyyCjCKMNpUDKk2YyDLhcV3t0mxJMZEGiZe3HyDWWUQypT2DEYAkbp9Ha0YJi6dnGf+9BUG/QKAMpV1hDpLBvhYlHGjYlBQlAVREw1psPlzA68N8pEKgNQ16r78folvP9aZOXiMYRmJGpk52uLB87ukvAXcIN/+vvXq3rO0YKqYGqqKmaEpYX6WeGKDQ9MFRRoSNbLza4fe7ymOl9dfA8h+pvHq8sUv7en2uRgT3W7388en67N71vsd5/OPZj+kYUqfVr7OjZ//BRjUGmnYsJxdAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Poland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKTSURBVDjLlZJNSNNhHMfXpUtGBJGXbgV1sIOX/0WMXugQ4aGDnYJCUtYfxM2XueXmGrgX39Jtyl7VmdvAveAmCXMo/uc2zTXL3GBjgSl66yQMQnz59jzPQVpOosOPB37P7/v9/Z7P8xMBEJWL2v6rF55FKlDruZ4+r4bGuRdvFm8djyRfQ7/0EtWWK8J/GWiEGkx8kmAxH0Do2wRkH+txt/+yi95NTU1hfHwcdrsdo6OjL0TJZBI04vE4BEHAe+Expj8rESvMwL9ugjPxDt6UGbz/Kar1laz28PAQe3t7GB4ezooSiQSOjo5wcHDAwrhUD120DhaBRyTrRnDdDt73APdGrqFKe+l4f38f+XweQ0NDP/r6+njR8vIyS+zu7mJ1dRU7OzugOUW4hhh8wMxXG55YK1lNIBBANpuF3+9Hb2/vo1MGCwsLWFlZwdzcHBeLxRAMBrm3wfuIZFwIfbGhznrjmIpNJhPn8XjY+3t6eu6cGkQiEWxubjIGW1tbiEajkAceQjpdg1euKjx33GSd3W43NjY2aHd0d3dXlPxCKBRCsVjE/Pw8CGludnaWduLouAQWR8V6vZ5zOp1UjDPfSAqVqVQKhUIBVJzL5eDz+ZDJZKgh6+xwOJBOpyGXy0/K7sHk5CTGxsZgtVphNpspaRDS0Gq10Gg0UKvVCIfDaG9vP/nnJpaLzs7Oi21tbWhpaflZYuByuW6T8WwWi4WSxuDgIAwGAyXNunZ1dUEmk6G1tZW9nef5YokBgaWkp9FolAwMDGwTseTv7lKpVNLc3LxNxJKmpqZfJQZkp5WENFuUtbU1eL1eRlqhUKCjowNEDJvNxtaY1KKhoeF7WQY6nY7BUqlUZyYQi8WSxsZGKsaf+d8YX83UE3LzXQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAH/SURBVDjLjZLNS5RxEMc/8zyPz25vLFkEUodfhpBFGpQhXSoivFl/Qp46RJeC7OQpSAJZglow6BDsKRCCoEMdKgwTUShfLtZidFhpsyV7xM1dfjPdZLXQndt8GT4z850RM6ORyOVyliQJ/f39Uq8HNBiqysTExD96VJ8MDw8Pmdl5EWkB9gNNIoKq4pwjiqKtAdVq9WZPTw+pVGq92HuP9x5VJQzDrQGqSiaT4czIXnZESkUFMPbENZ52f99+giiK8N4joXH7nBAFhgBD0xG/q7o9IAgCarUaEhhxCJgRABIaGI1NoKpICAOjYAIigICZ3x4QhiGqyrOOWVR13TzvPZkw0zhgJMmTSqU4/PkYra2t7HvwhMmr3UjbEteyVyxZXU5+rZTvv7z36a7Uf2I+n7euri7K5fJ6ZzNjpviBctM8p9pPc6i5jTdzzxmfHeXrl6Wh4H8eFAoFVJWFhQXMjMlvbzl5tBMfeDpbLuGlRveJswDXg80rmBnOOQCcc6gqP5MSTbKb3vYbANy6+JgjBzoA0sHmM6oqi4uLxHFMqVQinU6znJSZK44x+LoPgMFXfRRK0wB/NgBEZKVSqeCcIwgCnHPEccyF45cZnx4jJuLFTI5YIt5/fAfwaIOJ2Wx2YGpqqndtbQ0RqQeztGv+4OrOH82GxkAC5MYfFu/8BdnT67i+1n1kAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAANsSURBVDjLdZNrTNNnGMWb+M3wRaObc/plSxYToiZzc94quCGCVRfMnwYtUiyuUhUQKqtcCmhatAgEaKlcBNFSBYQ5lSIgQ0GFttRCL0BBoAVUVFKo/UtLBXJsiZp5+3CS98N7fjnnyfNQAFDeK1uf6nVGm5CSquS28VqPzMY0RcweVjDawmqC+QevZi6IvfJk4f//e/ThkalL8RFqTg7dHqhFo6UJiuEGdLzU4oq2HISMJo0pH+VwLpqHIgoHfD4DZHQlB1V0l+GOpRFl/VdxXMsH91Eqavr+xd5LO62MkuIfI0vN1tLWcXAvD4IQ6YI+AESdyYtPq0+QzcPNEBklYKmjEa6KxvmeUkhbxNgh3cZhXxiSZteOQWEgUXDnBWhpHeR23sPF8wB3X4Gi/xaKTJfBVEchpI2NeE0aZFoZ/MU+naxC489h4r7Zmzo7shrGUaWy4fgFE6hRTYJ5QHxLZGe9uRFRmkTsc5vZyjjI+isQVREJavpvWw7kme5nK56hWmODpPIaTPIQPL4hRFeJP3T53mGUo/XhrhuWOsRokiDS56Gyrwbn6kXYJPi1hJHbS3f3dVQqJ1FcXYaxZh5s+lqAfIpJfTXaMwOeU8Kv023K52pc67sOyd08+GZtsm48/UtKfeypJbnx5cvcffU1dXKMG9PgGr2JsXvn4DD8g1nLAxgusp0Uunx3p/hujqfvS5+MDXGKWGLlNJOZ5AymW6doe1bzMnLMViMfc44HcAweg9U9p15ZBJTSgzPqvKCfKLuK/Lh+uVS2IZ71vYv9V9Z0aChJpiTjdcg+jGZ6cyYMCZhztmNqgAnnCAP2nkTo82kgGAnF80Oc+fvEojfHjha6WCzXa6EAkxUyWOVlGGRuwVgH7505DM7h/XhlTEK3JBB+BH/qO9+MpfOAN0c4S92RSXthPiaq5Hh2Kgn94mj0KuLcsVvhNEdgeuQAbO4kPZIA+IcWYNnWs8RHm+jYSxAki4WJVD406Wx01yVCdzsHT1TBmDIzYO06iUc5NKzfnTbyLTU94Iu3YN/su/3Vug1DVaI/ALsFpiICzYnL8bAgELX8za4/6dzz31CFXl89Jo8mVq3xEhzynnO1S+BS5UIl3IaqQyvIhoQ1az81fhHgUTB1kfMMc9XMf2cDZ5qyfm+5xVv9w9fMHr0Fh4yy26byoRwAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Finland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAACwSURBVDjL7dI7CsJAFIXhrCMLOm5rlmAjgiA+CtNF7AQrsVBEtNBBBBERC4kBIZm8JjHHuAAhInYp/vJ+cOAaJI1fMirgA1DLzSKRIZUxIvmAJ264m98A4tnPma0003lCv6t4wkWUBlJo+T7WvYBxo2gYcYuDLA14UFJPE8ZNxageMLBCLrApDzhwhdfxGdshw4Gi03Y5wqT8hDOu5h5HscZOzrCUNsaiBcusPvFPwAtRJv5/iiq/OwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAANZSURBVDjLVZN7TFNnGIdPTMwSY/aHyTJjYkJmIjNT/zCLMS4uoomKRhMTTcjwMoJCWDTGeUFAtmIkoKIoA4QqoJRLrKyzLQ63qS2ltDtcpOXYQi1SbMFSodALp1fbn+9pgGwneU6+vN/7e75LzmEAMHNPmSWEiDASPcRnQv2/UO3L+XmWSF6oM7MyZilxfa43fTwyrYK394iLVezXnn8eURPuedT/Kg5qfAM50wHzZTf1s8TqhMDVyhR42aMT4cmnmNJnzPZJt/pLtdOo7HWhzuBMIIxvaUZhkG7iPVwR7zec+0C5fmIp43jAFPqMl92TXRmzuqat0Qq9HY+M79GiGUO1zISKxyY8eDGKloFx1HeqMKTYHQs4Hn+cfLLOQtlk5m0ts21YvMzSfX8jf101ilbWDpnKhhGHF9NeP6a8c7DYvZD8PYL6LhseyctgbNkSMos/f0XZ5MRFnK9T3sj9nYNYa4OUVhOeGY8HbyacCNJYwB8H/lA2Y7g5DVZ5MQx1u2Cs+uZYQpBe26++0MahpsMCM63MR+Pw8zyq6hvgIpEvFIL6WQmcL3PhGWwn2wRmB9ugL9szmRAcuq1xn215hWvNRrgCEcyEYgjTRJ6oCE0yOe7dyYDbJELYoYBTfQMBToaPY1pwDVnBhOBASYc76z4LUcMA7P4ISWJweHy4WnYT1eXZmHldiFhAi8DbU3D3nMaQJBOsODPeU3FwbUKw55c2dVq5CkWSfnRaPXhPh3b4Iuj8pxozXB5iQT34keMI2tPhM+eDq9mH7CuVfYnvQHilXHgo2it6gjP3dCiVWjBFF2YdlMPZmzsfPobgux/gfV0Ac1Uqhe9CyCwKvjtd/S1h2lWoxNlaDWrqxDD/dZG2rUHQlomQ/Sg8tJOhqt1I+7UJQq+QWRQIbD5Zlp1TKuGzfr4I05/5MHbcxjh7GLwtHW7DJQz8tg8/lUhwovghL/Qu/gsLA51Ol8JxHKTXdgK+MQyLD+Fl/ip016RCKdqOjLxydGm74906XZx6v/+foL29/QvCb7VacTVrA8L6SoTZO2CLU9CcmRTf/2NO3/q0ApFCqfRZLBZQb5RYsyhobGxcTgwT4cPbVoRKjn8dfVGaGn1+c0enMnfDVwur0XwS4SEmiJVC7RNi1+PWy99nOwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHiSURBVDjLpZPNaxNBGMb33/DWoxcPngr+B4pQggdL8WNbaxQbGtugkESE0IZEkiYhpC2GtJQatKW5pFYl2yrKCrZVrMYo2jbHfJElm/1IPJXHmdklbZGURBd+PPO++84zM+/ucAC4/4GzjC2PTKXzuvvZPlxPCcldOBd/4v7Cd9ybz8Exl8V4fAd3H3+GfeYjbLEtuOLvdTqPGXhT+YNopoxusUfeHTADuvK/YA28BTNwJffQbDa75obvtWHgfPILjUYDOkOHrutsLIpiWxqkhvcKpgFpmKqq6J/IttBITAvbPZqm4ZrnlWFAu11XFCh1glI3VTnRgL6/8vCFYUA/Va0mQ5Zlpgy5RrRGcoYeIht5wsCDVcPAkfgKSZJQNaFjqSr9de54KozxmauwhvrAPzoPi3PMMLDPfkKlUjnWAxofPcLzD0vwrAxiLTeNL0UB4fU7uBw+g96RU0FuNLaNUqlEKJtqcNRgKHAB6W8RpH9EWRzcuInwxi1q8JuzRTdRKBQJBRQJhRbFll50n8XLXOJYI1ez09QA9C4s3w6J7M8a9r/BoHcd1ycypMtrrFH97jTO2XoQEIbgE3g22ZfhD3fQyY0jhZOXgqcxJQyzlanSmPWg02tLiv0ElW7bVD/N/wGu4yJFlYuLaQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Croatia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAMxSURBVDjLTZNdaBxlFIafmd3tTmYnJU26TYgNbZoQ7GIMBH9iNQj1QimIFCL+EVEQQa+VXBQKBfVGIlL0QtDeBFEwFSlN0EaqgkaQ2tYG89OYxiaN2d1ssplNZmfONzv7ebEx9sC5fB/e874cQ2uNN26YwGngJCBAf+qEFu4ab9xoBi4BAfBy6oSeAzCKX5MA3k20vfTinvbX7vEXP8vPrrrzX9nnK0D3jn5qoPycmWlrycSTTYbMvvMXMNBwUi8buS84ZR0ZfNM69HxraXF08/byXPz71guOk4yoS1QB8EMT5Xsczw6UDx99hlhU8sozw8tAn6kE07AOWcX50c35hTlnsu1Lp71e0ej7yK0NvPkNnJJHS/0erjYP26uLk1asqa9R1x11lHDEWPiE/tCwP103Ow/+0vGN3WbHSZYj7u9spGGvicZgw434bXaNsC5GauM893qjktienk7q0guG1pq3z118P9Zw+K2OZocG0Tx7vJ2i61LwfNpaWwCoaPh8fIGqo8nmVyl48fc+fuWRUybAaqX1waqG6pbivq4myhVNIpFg4rtvKbkuoQiXJn4g07UfN+/jm/twVfJRgDiA+F53RRm4UqWpqQ6JNCnb5s7SEhOXf2Lqj+s88eRT7Dtgs1bw0Q0JxPe6dwHK9/DKSfyYgUS13vLuFinHYXstR+fBVm7duEZ2ZYW0FIndWWd/GDaeOXP5d3MHMFXaKmPEqyxmy0SGCaZF7wN9xEyDTCZDV1cXxWwWQpdMJkNPTw8i0mvunPBjyXXZCIRfr+VIJCFlJXis/xhhGFKpVAjDEK/sI0pQSiEiiAg1B4F30V3/Z3pmaZ1cMce50Tlur2xiSIhSandFBN8PdsUiUsvg57NvXHn49eGzHanND6YWK/b6lpDN5YlVTQ7cJQ5EiELRSilDa/0/AODDV4/drK+vt/OFYnR69GZsxrAxYxZPp2uAMAwxq4qqjgyR2p8ppWqAsbGxNHAhnU7jbbvudvHvj6Kqfhzolr1mo4gQBAFBEGittRGGIVprlFIYWmtGRkYc4ArQDvQODg7++Z+zoaGhG0qp7p0wJy3LeqhQKMR3gr36LzexzEk6GOJQAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Portugal",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJUSURBVDjLpVPNaxNBFP8lqY1JSJOGFBtSU11BaEulUUFB7EUalB70kINCQfBv8FgNgvRUJCdPUj36FxgqKahpi18NSQXBikRbE6UfYpNtsruzO+ubTTaHNoLgwuMxs/P7eG/eOEzTxP98Xfs38vn8Y13XpxhjXZRB2QpN00R+mkwmb3QkKBaLAQI8CgaDSbfbC5VA4ByWP3LZ2xvE/HzmOq0OEhQKhcsCHA6Hoz6fD6WvZQh1zk1wkxORCYPIVFXtXAIdzsRiMWuj0VDACPyhuEIEvB0TiStWGR0JRI3d3d2oVqtNZcPA8MiYpW621EWz/+pAMBsEEofEpQjrxcI7yoalLv5FJq92dOAQoGw2a8bjcdRqNTrEUK5st9XtnNm+g7omQ+O698mt1YZN4LQdNJttWmEIZaNZ+5a/hLnfaSg6w0B4CApj9WsPj3kOlNAGt4DPNqdJmUH9weCjvvSFTmKo/xxqyh6K31/L47OhwKvbv2SLQDTHnkhhWfRA5xomRm7CoLXliCaisruB0YELkLWGc2X95e6p+85Q24G4BZfL1aybXCi6ZoG/7XwG4zoR0kQaDFW1hrGjFyGzuvNNaXHH2XLwNpfLQZZl+P1+HPa4iUCBbug40hNDf88gIgEJh1we9PmjyG8sYenL4lZdw1mHbT2dTk/SPNyLRCJnjksn8GB1Cgo506gU4UYKD+O8lMD79WUsrD3/qem4VJkxPzr2v8ZUKpUgolmKUfsxibwcncPpwXG8WFsoa9wCf2rPwb980l3HnsFd3gY3pM0Zs2Tv/wEq26vP9fcF2QAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAI/SURBVBgZpcFdaI1xHMDx7/Oc/3ms8xiZxLxcGIXF3cnN5KWUXIrc4EZcSC5QKC+1xjLKW5ELLzfIS8iNS0qUtxqllkYstllsNufsPKc9z+/3s/9q5Vb7fAIzYyKCDXvv7F6xutg2ULHYDFDFVBEVTA01xURQM0wEUWVKlA53dHQffHBm80VXbCpeyNfE4cwa/kc8XJELwEVXSS2sDJT5l8uGaeptYSRLSRLlw6LjZLmYfyWphYxyJsaJLQsZlyZ/eHejhXx9HaVywuyGOqJPR1m//wb5mlrG7TjZhReaKd5IJgyXB3l/ax+hM4ZKVWoa1vLr+1em18/lYetWvnb18OVHCU9U8ELM8IIw4OP9Q4RRQClR6tccYMmqbcxZuYdvnZ0UptTy5Nx2CnmHp5ngOVHBC4FqdYhUI+avP8a0GXNIK7+Z19iE2RGeXj5Mlma4KMRTUTxnaowJApbvvMnjR/eZNbeB022tDA4OEccxzc3N3L5X5EDLaVDGqApeqCqMC4KAVAM0HSGfj2hsbCQIAjAjF9fhchDmGKOqeC5LU7xXvS94/e0Nn8odLO1fRm1cS6FQYFJ+Eu0Dbykt7+H8szYWTl3MpuJGsjTDcyaKd/PldZJKwkDvENcuXyWnjr6ffVSrVa5cuoosqPK5/zntSTubihsxVTynqngt606RiVDuL2NqiAiqiqemOOeYPG0yURThqRme6/7SdXfX2XSziqCiiAiqiqQpqoqaYSqYGGqKqaKKd5dRgZkxESET9BfqVjgB6mRiLwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Poland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJISURBVDjLpZPLS5RhFIef93NmnMIRSynvgRF5KWhRlmWbbotwU9sWLupfCBeBEYhQm2iVq1oF0TKIILIkMgosxBaBkpFDmpo549y+772dFl5bBIG/5eGch9+5KRFhOwrYpmIAk8+OjScr29uV2soTotzXtLOZLiD6q0oBUDjY89nGAJQErU3dD+NKKZDVYpTChr9a5sdvpWUtClCWqBRxZiE/9+o68CQGgJUQr8ujn/dxugyCSpRKkaw/S33n7QQigAfxgKCCitqpp939mwCjAvEapxOIF3xpBlOYJ78wQjxZB2LAa0QsYEm19iUQv29jBihJeltCF0F0AZNbIdXaS7K6ba3hdQey6iBWBS6IbQJMQGzHHqrarm0kCh6vf2AzLxGX5eboc5ZLBe52dZBsvAGRsAUgIi7EFycQl0VcDrEZvFlGXBZshtCGNNa0cXVkjEdXIjBb1kiEiLd4s4jYLOKy9L1+DGLQ3qKtpW7XAdpqj5MLC/Q8uMi98oYtAC2icIj9jdgMYjNYrznf0YsTj/MOjzCbTXO48RR5XaJ35k2yMBCoGIBov2yLSztNPpHCpwKROKHVOPF8X5rCeIv1BuMMK1GOI02nyZsiH769DVcBYXRneuhSJ8I5FCmAsNomrbPsrWzGeocTz1x2ht0VtXxKj/Jl+v1y0dCg/vVMl4daXKg12mtCq9lf0xGcaLnA2Mw7hidfTGhL5+ygROp/v/HQQLB4tPlMzcjk8EftOTk7KHr1hP4T0NKvFp0vqyl5F18YFLse/wPLHlqRZqo3CAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Brazil",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKOSURBVDjLdVNNTxphEH5YVhZFRCCNmB6UYmgIRSJJD6QcS0QTT7145NT/4KUXY4yJHjzzB/gDJl68NE0IJCbaA+GzJBQBQ1RU1ALLbmfeAqmJTjJ5331n5pl5Zmah6zpYSQw+n+/z4eFhxuv1xuhb5rehyqFQKJJIJFLsw2+jOHEpGwx6i72OjvB2ZQW/T0+hbWzgDf4J25TjY7iWl9E4O0NvfV3YPLpukAwk7GRRFFhsNgwGA0zb7Zg0GmGXJKFmcjFbrcI2OTMD8xCYY6XhHWZZRq5cFk75YhEagXRmZ9GZnsbAbEYunxe2XKEwBsCIYwnQbJT95/w8ip0Olii7m6hJFKD3++iqKn7RWSZ9p2kI0flI9iVAkv+v4IPTCb/FAr3Xg0pOGiuBmQjo/cQEvHQaSJX7ezwS6LiKdDqtq6r6qvb7ff3p6UkoC79xDMfKeEG63S6y2Sw8Hg9KpZLgfnt7i9XV1dHIxyK9BMDBtVoNVup8MBiE2+3G1NQUKPNYR0DPKuBHzn59fY08df3m5gZXV1dYXFwUQLRkcDgcwm6nKYXDYcszAOKKZDKJh4cHxONxcXIlqVQKzWYTG7RcMjW70WjglJbN6XR+ewbAjpVKBV82N7G3tyf4u1wuBAIB1Ot17O/vCyBaa0SjUVSr1a+SPiRDh3Z+fg4LjZFle3tbVLRJYJFIBGtra4jFYujRiLe2toQP7Y4iKrinuXZIKJs1k8mI1T44OBDd50pGoEyJ8+3u7ooKLi4u/ggAbpjRaJxhfu12G99PTuD3+0Xpl5eXKND6KvSvLCwsYG5uDhptIyViWk3xN+7s7PygkX3i+93dHZgKNQgmk0lknqV/gu+tVktUwDTortI0Pv4FgnWCE6f7EysAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJsSURBVDjLfZO9a5RBEIefvfcuucRUanGiJkYjiNoEET9II0gUsRC0sbASO1G0MVhIiCL+BdoJYmOnjYWJQsA0QRBRYkBUJESJ+dJLzvfe3Z3dsXiTS6LowDKzC7+H3ww7RlUBCJcuKrv3IkNDqAgaAtF74lIuHT+OPh9m3YtnhlVRXC5Wi3SVMIrkdxHUef6MFYAXVIRoLVEkB4k06uI/AIUGwHnUWujoIFhLtJZgLSHLMF1dxLSOOvcfB84PmLnxG837a7QcaoJisvRukDTDvRojOD/wT0DTyYlJpFDze8612aZ2QiigkmEkpVSfoFx4VDOHw+SfAKOq6MODB8A8cd3XK9Y1E9OfSPYL9RkqDkxCc9nQ+uHeFF5PlS6Pja6dQZA+2XW+YqWFkFYJLheqd8QsRaqzpPNVsvbTlbgY+v4aokbp8eu2E+uLuVAciCd6i4oj+jqyMEddWsGGnr9nEHV91AT1GVEcGjxRcnFwea5+GqP6Ypxsempj6C1OAHd7B+XO0hA1/0TiG9YbJziqn8eJUmPfuSs0d+6h/nZw6/uXQ7eGjpZ+LbWg88bXIIa11sWi3jEzNsrOI2cofxrGPDhL6+fHbOvYkKjRK7mD4EeK1fFTrriZGNwa6yqOWKtRrnTCiasrvfdvIolmW+6gHu8UX9+fKpmUQqkMMaIh3wlUMW2tpG+eQv8m7DXDj2uGhe8zhES/meVtdDe7LiAMuO7TlaxpM0EialPwKdV3wyzMTrNlg1AsTLI4I3z5ngSf6Y0GACDr23Eg1qQPH3uimvUEUDXzURj5KHybm/16IgmmIyT6VeHesUG5/Rt5eNFI8xvNdAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHlSURBVBgZpcE7a1RRFIbh95yZXEaSSLwWFkFEkICKhWhhIV7AxlKsbSz9DQpa+gfsbERQsUhnEYOFFiJoYSrBO6IBY5I5c2bvtfb6jCIIYjfPU0liFDUjqhlR99r9FfEfHoFZkNwxg9ZFm5xkTptFY0HbOl02Hdvf4y/hIUoRHsKLMBcWgZkwD6wE2YNbi1/p8sf6wCkBHsJLkIswD8xF9iB5IZtIHmQLtk11aftOl03nDk/x6NUGpw9OsTYo3H26yoXjs/TGK8Qmwav3A5aW17h0cjfJg9tL34jWqJM7gxTMTnWIgImxmjYXeuMVNxe+UAFX731kbuc483t67Nk+zt5dk7QWROPUTXKevWk4um8LD5+vMjlWcfnMTrqdin4qCGhSIQJOHJjhl41hIVlBTaHut+LU/DSPX69z9tAMgxTcePCZZKIZFiRohoWQePmuz4eVhARDE5Ey9VqbsSKeLK/TqSsk6CdHEk0qIGhyIQQ3Fz7xY+Bs7XW4fnEOJVGdvr6s80dm+fQ9kS1IHiQT2YPkQfbAPDAXVgIrwkPM7Zhg8c5buusbTpsL05Md8ljFpFXYhHCvMK+xEFZEKYEHlAgkkPit2nflhYatIxORAmVHFigVyIFKIAvkggj+VUliFDUj+gngimmFTeOsxAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Haiti",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJ4SURBVDjLpZNLiFJRGMe/q1biA99UpqOilqALmYW6yM2MFLQtwU27bLbNLLSgidEethxcGLRTXIkbFyEYQlQu7qJNMD5AYXxcUZMRMhtf19s5NzRnExMdOPfAOff//f7fOd9HMAwD/zN4/ypIJpPMbDaD+XwOaL1PFAoF1sJisQCaps9M/NP6xEKj0QgOhwO63S6k0+kjHk7B5XKxgr+N6XQKqVSqbbPZ1LVaDbLZ7DEKGONhcrVaBaFQCK1WC9RqNdTrddBqtey+Xq+HSqUCJpMJJBKJutlsQqlUwgEfBAKBPM/tdhP5fJ4RCAQwGAyc6IDs9/vOyWRCIpvO8XhMdjoddm232+z+aDTC6VDYGQd/cH4ikQi7IDFZLBaTmIyIJCbLZDLSYrGAXC4nrVYrBmEHLawlls+YyWQYj8cD6FKh1+s5sRiTsZiiKKdSqSSRfadKpSIbjQaEQiFi5QAPZGm/WCyCwWBgyWazGaRSKUtWKBQkujzAQex2O6aviodYL6REIsEsn2vtrdmp6X6ByxQJvEEPRnwh8GfDJ7dy89fEeSqx4NMFxRp1+PqW9+IlgxVOv+ag+Ok9PSiXdtlKjMfjNxBlDxEfLonrDjZ/jGBzywv82geAjy9AIJGCXqfjnlSY3wFQTl6/378TjUZLSPAICQ+DweDh0kF+++WCf8VAwJ29Pz1wcBW4C0LPphCLxZ4i4XONRsMWEK60crm8cnHz6C1s370HwsY7mJx24CcKMPzOhXINqDN3EIlElo2yGw6HVw4++64dXBCL9jcUMw6P04Lhtzkcd7n0bMw8I87bzgXfxuPRSXuHSxM6mstQSPXmdm7+6heR5oijWAuHSQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Ukraine",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAE3SURBVDjLY/j//z8DJZhh6BgQMuWBQumq5xdaNr/84Nt1t4FkA5LnPd4A1Kjg1XaroWH98/9keyFx1sMLKfMePcAwoLy8/EBxcfGB3NzcA2lpaQfi4+MVwsPDD/j5+R1wdXU9AFJjX3GtIWzSvQvmOZcMMAwAag4Aav6QkpLyH6h5AkgMqLkBqHmBjY2NgnXRlQCn6msLTDIuCBgmX3DQiz+rgOEFoM0OQM3/IyMj/wM1F8BsBmHv1psH0uc+/J8868H/sIl3P+AMA6CzJwQGBv53c3P7D7RZgORoBNosANLs4uLy38jIaALJBoCcDbS5wNra+r+BgcF/BQUFB6IMANkMDbACEF9TU3MC0AX/JSQkPggKChoQNABq8wGQs4GaDYA2HwBqPgDUfICLi+sACwuLweDMTAA2jKFj5WHetwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Ireland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAH0SURBVDjLxdPPS9tgGAfwgH/ATmPD0w5jMFa3IXOMFImsOKnbmCUTacW1WZM2Mf1ho6OBrohkIdJfWm9aLKhM6GF4Lz3No/+AMC/PYQXBXL1+95oxh1jGhsgOX/LywvN5n/fN+3IAuKuEuzagVFoO27b1/Z+BcrnUx4otx7FPLWsJvYpIM2SS9H4PqNWqfK1W8VKplHlW/G1zs4G9vS9YXPx4CaDkXOFES4Om4gceUK2WsbZWR72+gtXVFezsbKHVamF7ewtm/sMFgBJZhd6pvm4kDndaAo2KOmt5Gfv7X9HpdNBut9FsNmFZFgPrMHKZc4DkjHyi6KC3MZNehTOuGAH5Xx5ybK/Y3f0Mx3Fg2zaKxSIMw2DjT0inNQ84nogcUUQJHIfZquNT3hzx46DBALizg2o01qEoCqLRKERRRDAYhKYlWRK/AJdCMwH2BY28+Qk8fg667wdXKJjY2FiHaeaRzWYQCk1AEASGzSCZjP/ewtik5r6eBD0dM+nRSMb1j4LuPDnkFhZymJ/PsmLdazmV0jxEkqKsK+niIQ69mKUBwdd9OAx3SADdHtC53FyK12dVXlVlPpF4zytK7OgMyucNyHLs8m+8+2zJHRwG3fId9LxIbNU+OR6zWU57AR5y84FKN+71//EqM2iapfv/HtPf5gcdtKR8VW88PgAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAABbSURBVCjPY/jPgB8yDCkFB/7v+r/5/+r/i/7P+N/3DYuC7V93/d//fydQ0Zz/9eexKFgtsejLiv8b/8/8X/WtUBGrGyZLdH6f8r/sW64cTkdWSRS+zpQbgiEJAI4UCqdRg1A6AAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJgSURBVDjLY/j//z8DJZgsTV+9fAu+uHo8+GzvXECWAV+c3R//mTn9/ydLu4eka3ZyY/ts63T3k4Xt+4/GlqS74JONY+9Hc5tdH4wsmAmGgWv9xQKX2nMPnapOF4D4zxotum4sjfh/e2Pr/wtz3f5fnKodx/A7O3P97/TU37+Sk9ajG+Bcc/bJnI0X/hfM3/t/YlfJ/ef7yv9/uLTl///PT/+/v7Tm/8Eun08Mv9NSf//buun/z9jYvz8iIs0Qms/YO1ae/GBfdvTNtMm5y99dqv338/Gm/88PdP//dnnd/z8Pjvw/PzfjH8PPxIT1P2Nifv8Ij7j0PSjk3jdf/5Mr4poWOZUfe2hXdsT+yXYVj3eXa/79/Xbk/7e7Of/fnsr9f31x8v/j05P+Ruf1tqI4Gehftv6UybvP+CZ9+mDr/OpVnPGjd5cr///9fvz/1zvx/78/iv7/6VrV//szHV6c7XUxQAlEoH8lHKtOHbMvP7bUtuQQ5/F8pbLnp8uhmuP+f38Y9f/jler/d6Y6fbrZY2YCT4mudRcKgP59DvTvG6B/S0GC25olg6/tKP7599uh/9/vJ///8Sj2/wegS25Pdf52o8dCASUpO1WfeTB5zcX/QP++BAnMyZRNvrqt6v/F7RP+PzkZ+v/r/ej/by9U/L81xfHljV4LJYy84FBxvMCu9PADm6L94Lhe1en8//+nB/9vzAr5v69K6v/RGZ7/DzaZPL3UYa5DVGZqTtX+/fP4lP8/T078f7LV8f+qFJnPOyv19InOjaG2gt/b4zV+7+3w/L2n1+ng5nJdJXypFQA6mcPFnqo5OgAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Cameroon",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAE3SURBVCjPhZFfK4NxGIZ/R458Dz7B7wv4Go5WpJW8819mSw3bos202DsTNpT3FTbCRs0YkYPFasvKJhw5kpVEu5y8W0uZ7sPnup+e+34EorH+HIRZQsXfLtKkOSPJCXEOiLGNxgarpPniGW9WnPPN5y+9E3p5I4+n6DaLFHmeuOSRFEUSFNgjj04WDVcbQiCOuWBfnrIlE0RkjKDU8ck1VBytCIE45JYkD8QpECOHTpYIGVzYmo0UO5Q5IiyjqFLDKyNMyUVs1GJq1mvuiZJjkzvCZAhyw3ClrocVQiwwhwc3E4xjZ5f+SoOihpr66Hk1gOWWYGAeHzM4cWBnlEF6QZjLBqBaEbPKdMmpVP0WpbtkVjo/DMBv9aJzxTo2RhjAQoA0fkyFuhsmGWestqFL6cDEP9+s6gcdbFPqiEGjeAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Argentina",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAD7SURBVDjLY/z//z8DJYCJgULAgi6gUvvEWEOVY6aqJJsxw79/DAxIDrxw+9ee/blirnhdYKjHtcpKmd1YiZ+JQZKbmeHivV97+j0EGEGaGf4T4QIZPiYlXhZGsM2g4Pn/FyL+/x+I/Ec4DEA2vv32jwEetjAa6B2YYXgNeHD/Z9iOM19XP3j3h+Hbz/9ATRBbwbH19z9hL9zrkn0PpMIUCh4Jaqpz7IZF8/8/DAwMWKIcZzQ+mCD3/tu3v+8Z/sC88h8aDgRcgAzAfoa54C9WB+A3AORnmCYw/ZdEA/4hO/kvAwMDyS74j4j6//+w6ifkBYQmXAmJccBzIwCU7Hm5Y0odkQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAI6SURBVDjLpVNNaFNBEP5e8hJiSjVVTComsdYUMbRVUhSVgFawgqgo6FFBaMEeehQ8WAQFj57FCh4KVixCERXipQhCa6kaEz00uSQIghibNn++t7tv4+6mTU2bi3Rh+WZn95v5ZndWq1ar2MzQ1zuGHs85xwaPEIF9qz5uWbBW5vjIiY/Sd+n+qz5GKbT1CgRxnwCPmPPBHW5wLolcBTEJxfT7+RtccI5Fwg9RtdYU3Jwddgp4DVwfrXJrBpoNt87trwfmnCP2KYvU9z13ZObTB/04e7izoYRvFrP8qwspV45kMqlsxhj6u7uxd7u+q7V1KwK+NsTj8VoJIvsXn7O9Vx7K5rMgJkVpqQzTICjmSwrl+unQJDKZDMLhMLxerwqqC/IHr8PX29HSCcYZ/C1BhRVigHKKP1SgxTAx8QwyWaFQgGmaSl0qlYIuZFOmMRCLKCITh6lA0zIFkcJkZs1HmCL9e+mhUAj6g+ij6HDs2udypXLIZd+C7M8sfuVzDdJlSYyyBrK00+n02jNefX55gRgkyAo9I05ycmx5aRlTty/AMAxVKyEEuVwOiUQCkUgEgUBA+eqvIMg9IuNLe/H4V2arEeRwuVz1jG63Gx6PR01d1+FwODY20vm7U0ftNm1m8fciKCWidrqCNfti9IAKNv5mVvjpxlbWgB9yo2P3zqa9/+LdnLqPMwP9zf+ClC4zZgrFpgrafV7VWLG300qB9j+/sevKvSflcumUbOVtnraF9OTogLbZ7/wXRdt3lZxkvhIAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIuSURBVDjLjZNPiFJRFManVo24jYISClqli3KGp0VY7mSCBqKoIHIIahFtStwUCPVGIiloRJmkqQERiqBFIZGtcgrHrCGaFo+hCQlCU9/T558n/v+699Z7PBmjDnzcxbnnd8/53jtjAMaoSOwkmiDi/qFdRJu1Oh1gotVqyd1ut9/r9TBKJI9QKDSnh+gBXKfT6cfjcbhcLvj9flQqFVSrVXYWCgUGyefzCIfDGkQt3kQBklTGvv022A84yWlFJpNBvV6HLMsoFosM0Gw20Wg0EIlEfkP0AFEUEb53EYnnbpw5MYV0Os0KarUaSqXShpGYJ3pAWfyJ3IcjKH5y4NIpK5aX37O5FUVho9AHaCe5XG40IJlcwv1gAMLnFSw8fASfzwfiiwahnVA/JEnaCOA47mw0GkWvDxbZbBZmsxk8z2sQOg71hIKGAB6PZ9xms60KggA16AWv1wuDwcBgFNJutxmEaghwbPr4Ubd7hhUOBgMNkkgkYDQakUqlQP4PBqCi3QwBzp+bPulwHEaHXKIJNW4H7mDLuAHr699YB+ooQ4DCu8u7f7yaeum0b8ObpbRW/H31KSatFph2bCfGiRpAlQZYix16lnuyF8Gre/BgYRFKkzjekJGcd+L66a14ccuM8pebbAS9NMDHxzMX1hYt+ZV5S+3aFTcCd+cwO8sjduMg3gat+BqzQ3jNj9qNvubBn085SQxSaOJvy6QvJnfrbHt1ABOF/Mc6q6Krb/oFGtGkE2IcdecAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Greece",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKFSURBVBgZBcHLi1V1HADwz+/cc1/j2Az4qiYjhQoXIg5lr11tWgi5aWWLwB64FMJdu5Ya/QVFbkKiNrVKMAmipLI2UZJMZcmMM+k8LnPnnnPP+X37fNLHX9y4mHM6Pa7zoGoAABAAQLdk0PXRG6cWz0GZI7128oWD+waDQUqpAwAAACaZtpn6/Oqt13EOynGV+/3+IF26tm7inlG66dCBVcPupiay+1tDv96aMxNHlPZ459VD2pwSQFk3FEVHkaiLFYf2rur3/rZZjTRto+z3HT74kD+Xdpnv7ZUzAFBCRlEkVazpdddt7Gyq2om6aTSxrd/v266G9gwLIRAASsgoUhJNVrVTk6ayM63UudFmpKnIrbJIIgIAlBBBkZKBfUbby6LTtfzbebv7jOtGOdszk3es/Dfy/qd/yNGZO3Phelz9+c4zJURQFMlsZ8GdlbvmBst2xhMvnnjSK4uzvvz+X++ePgIALl1bk3O6XgQiKIpktrvfw8Pj1n9ZN66m7o8acOXHuwAmDVsVaxu1lLISIrh57y1tztqcPVGtWe4lnWDaZhfPLso5BDrCTElVVba2a2VESHh58RyAztENP3xVmFRT713+S5Fo2iy3WSAiCGa6WZlAAIB2OK/JoWobnaKLkLRSSiKHiKxppuq6UQ66aVOezh078CwpCRBG4590U+nsyd2aXKMgiJQNyp4Ln9x2b2tb2SvT5c++XnqubuNoBABtjrmOrmzHhzfetnfmUUlhbfyPN5/+QGFgXNXKM6eOnwcAgG9ufhePPciB2ZGXjp0w31ugYGOyYP+uxkyPMiUpIgAAwFNnr3z7+CPD5+f78wblA5o8lXKWopXT2O+3l6xuTf0PNZJB+2NWN98AAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJcSURBVDjLpVPPaxNREP7ebna3bX62aZMmYnVLxZRSior1IFVIC1at3uo1ePRQ8CB4EDyr/4AHFS8SCl4FC9IQf1WRhmij2Ei1Dabp0rSxRsMmm23WnZWEWBQPHRjmvcd83zfz3htmGAZ2Yxx2abb6Ip1Oz25vb4dNh67rqFarDdc0reGVSoViLBKJjBKOUQsm+KQoivGuri4raac1tykIAuLxODKZzOjU1FTMqsBUvO7xeKAoCiRJaoCagbTOZrNwuVyQZZlEr5nHMZZKpSx1r9eLYrH4R7nUCgEZY+B5Hm3VBfDLT8A7BlHaeIq1rdpNlkwmZwOBQJgSCVRXbY7k3I8YWgpLaO0cgVs+hK3lV0jN3NdsBCqVSsjn89YFUXKtVgNdJkXaO2sJhHo0OA4cR+HzR4hMg9PVDXfnHhsRhEmJiAhktmSVzHG/X9jXuoKjwy3w9I6jsjYNsY0h83YRVZ1D9J2ZRqrUKzkR1J32HcISxoYFePrOopy7AyZ8g+BwgldzqOyfwGbJgI0I6iAqORQKWRGFNzjSL8Hddx7l1dvgBB1aUYbybB6L9tPwt/qtP2IR0AsQQf3C1NxzuPwqfAPnoCl3wYsGyt/3Yf1FAsWBy/BL7QgGg1aVLBqNPjb7H6//MmwkET7WDZ354O14iXafaIL34ms8gQefgthUuUbFptgM2zlMD2+NGZOX7iE9fQW5lTlIPUPQ1/O5dpE/NXj19fv/DlN6SdG1D48gD43Abj+I1fnUz7KqnfkbuDELzXbhRId6uNdvG+6XYQiVOXU9f3HixsKXf03jL2qvd7dZXvRWAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Panama",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIkSURBVDjLpVNNiFJRFP7eU1E0KSLTMpAwYSxyaidDtChm0WYQ3NSutv2s2kwwm2igNgMtooUQEQhhA9GqhSDTQsZZFDbNDBgVg5bSw9J8rzFF33udc+HGg0ladOHj3nPe+b7zc99VbNvG/yy30yiVSl4SnCNcsixrivYEgY7WJu0faX9EKGUyGVNyFFkBkY/T+WkoFEpFIhEEAgH4/X7w916vB8Mw0Gg00G63y+S7mM1mm4LIAYxisbhSr9c5nT1pjUYju1qt2oVC4YnkqbIUMk6Ew+F/9hyNRkFJLuyaATmFoqZp8Pl88Hq98Hg8wtfv99HpdNBsNhGPx0XsRAG3241ut4vBYCDs8XgMXdcxHA7FN/b9VUD25HK5RAUczKC+hYgcNpNN05xcAQdLkqIoIlj6VFWdXIEUkAQGV8M2k2vaG3z6sYGfVR39XzsHlm/dX3h5d31xlwAHM5goBd5+LuO75z3OnU3jyP4EVrZeKGub2p309cP7VKcAQ2Znoiz3deMVTk1Nw1RNTB+ahamMkD45w7RrfwSYwFdFf6K4Quf6pmvwKHswl7wh7Jvnc4gfTPHR52zhcqVSeZZMJgOxWEyI8BC5CmOnh63WKtZbZczPPsa94hX4XCLJQHG+xnw+f5SEFghZmvhefgvcTqn2HN3gBmZSZ5CInMaHr1Wsvivjy3ZvSZn0nHO5XJDIxwgWDbW2vL10m9xXCUGCQXi49qA1/xvyq6BCh7yZeQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Sweden",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIuSURBVDjLjZNPiFJRFManVo24jYISClqli3KGp0VY7mSCBqKoIHIIahFtStwUCPVGIiloRJmkqQERiqBFIZGtcgrHrCGaFo+hCQlCU9/T558n/v+699Z7PBmjDnzcxbnnd8/53jtjAMaoSOwkmiDi/qFdRJu1Oh1gotVqyd1ut9/r9TBKJI9QKDSnh+gBXKfT6cfjcbhcLvj9flQqFVSrVXYWCgUGyefzCIfDGkQt3kQBklTGvv022A84yWlFJpNBvV6HLMsoFosM0Gw20Wg0EIlEfkP0AFEUEb53EYnnbpw5MYV0Os0KarUaSqXShpGYJ3pAWfyJ3IcjKH5y4NIpK5aX37O5FUVho9AHaCe5XG40IJlcwv1gAMLnFSw8fASfzwfiiwahnVA/JEnaCOA47mw0GkWvDxbZbBZmsxk8z2sQOg71hIKGAB6PZ9xms60KggA16AWv1wuDwcBgFNJutxmEaghwbPr4Ubd7hhUOBgMNkkgkYDQakUqlQP4PBqCi3QwBzp+bPulwHEaHXKIJNW4H7mDLuAHr699YB+ooQ4DCu8u7f7yaeum0b8ObpbRW/H31KSatFph2bCfGiRpAlQZYix16lnuyF8Gre/BgYRFKkzjekJGcd+L66a14ccuM8pebbAS9NMDHxzMX1hYt+ZV5S+3aFTcCd+cwO8sjduMg3gat+BqzQ3jNj9qNvubBn085SQxSaOJvy6QvJnfrbHt1ABOF/Mc6q6Krb/oFGtGkE2IcdecAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALHSURBVDjLpZLtS5NRGMYf6H8RIoT8VB+CZaKUsHIGGYgRpYn4IVdgmhW+zNnUTTZwC6l9SahmDjNTLJdtTtO11tBiOed8mS9zbW5zm9szd56r5zxKtM8euODmuq/7d87hHAYAcxwxxwY86pudlPX/itTpnAeVPXZyS2UnN1XfSEW3jZR3zZHrnbPk2tOv5Kp8hpTIpom41ZoRt5mTFxuHfackqklGPeDypNKEiyYyYDPIUvo/HVARIMMrtn+AQDhFCh4MLDFNLxa4Pd7Qjvjg8bPYTXBw7xB4AgTeIMFaiGAjzGE7ymE/DawGWLQb1rG4EUVJ9yzH1GmdYHn0u+9RaD/44N1hEU1yWYOBGIckP+wLsug0rqN3IoJgPEUBYO6o7AJgYZNg2H4IobskWAiDoTjH94HNEAvlkA96cwRjrgxCsSNAuXxOALj8BD+3CAZmQlAYPMJudJDef2uXRcdrD55PhvBlKSPoH6Dk8bQA+M3f27nG4r3tD15NB/Fs1Ifl7SS8/iR0fN0/FcSb6QAs7hRmVo4ASh5QVG9BigfM+1iM/wjC5o6g3/gRis5u6PV6NMsUeGtywbYUhlxx6Cm6lBgaGcMVxRSYc3c/cwn+zSacQcyvxtHTq4darYbf78fy8jLMZjOUPWpotH1YXHQLntVqFTKXa2Rg8ipeendjKbIRTHCj4yY8bGqCY2EB7fIOiMViVFVVQaPRoLGxUaip19rWzlGI9H49Yehvyrs9FD5b9yl9RnKPNLfKBEDhE9OB6EIhTCYTHA4HLBYLBgcHcZ73LrWMxymguaWVZP3r3Nzcmurq6jAFlJaWjufn56eLioogkUgE0Zp6tEcBNJsFOMkv/ogupVIZNhgMIaPRCJ1OB6lUioaGBqGmHu3RDM1mAXJyck6IRKLTxcXFK5WVlfHa2tokL7asrOwGrwK+3qMe7dEMzf4FvOYAdxCFF/YAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJgSURBVDjLnVNLa1NBFP7m3jQPSVKiTaskGKQKUqlSQZTqqlWrCwUX9bFx6dIf4MpFXQi6cafgQhAVJD7oLou2uFBEBLswCxFqbFRswZjHvbd3Zu6MZyYGiptKBy7f3DnnO+c7Z84wrTU2s6buT0wLKe86/+N8efZ88WL53NF15LNEflwY2pFjGykg8m7OxT7O+TMu5JQQIknkF9vzg26tXm9vqIDIOSKXi/mCQ+QKkV+WCkVLJvNBdq3y0EpQWkFFCpGij1BEEoJHCIWAL+vQqU/oz2TQ8X0sf1+BE45DihRi8eZJHN6TWpdTQypNQbooCYXUWGq9xXztFrRiOL3zDuJsCPfmfiLWo7V8Sdnxl6TALVFZMifUchRj2Zv2fLWRw9a0QtCR3QCnDqRRWWxjcjSNph/hyesGpo/kkIoz6K4oLNZ8LFSBS+MDCCngg4UVqEBQKVLCDxVyaRdUPhJ9DgKq3ZBvz/4AI/71p8so5eMYKaRQ2BbHrsEkAkE98yQcL5R489nDoeEteP6ugWQfw5XjecRchk4YWQUeoQl+bG/WltteM80lmxfB6QQaEyMZzH9s4cT+rFVzo/yNHDQ8cjRjYlDR5sOXDr6uhvZsjewq5HCaAacr03hVbcF1mDV2SJUZMJPZSPC4CQAqqY7f1Oz+lIuZCyXoUINNzlT1mbEc6r9CcKrLNMhkN503e25vonsbws5H93pLAwnMPVpCrNWWtmmZpAtO9ScFg0iQkySUDoTSlmSGi+LYQTMqey+ADV99r9cCkmxrIiM3e0IjnxMS0f6TAtvJfxbb7HPurT/OV55dSDB+9QAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Belarus",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJRSURBVDjLhVNNaBNREP7eZvNHU9aqBDxkiScvIh78Aw8qleTgz0lvHjwoivW/YBBBDxY8iIeiBiMoeBPBQIUqXnrQgxBy0l6aEkIWbDA0JTZtNrub3XVmQ7YEbRx4O+/tvPm+mXkzwnVdDJNsNuu2Wi1kMhnxL7uE/4jjOCgUCpvaZf7kcrknFMlRIcQOOm6nFaS955xMJiHL8nAA0zRvp9NphMNh/7Jt295ikEAg4DtoVyYvoGN8VF8/W/IB+JKiKDjwfgxR2YHucLouRkMW3hz65YNql2/dG5HsqfV2p0jH/X4N+AKziYCLO0cEHo67mBqn/4qMVdPB8ZYF7dLNi9A7M+bvNmKys09LnZnwASRJgmVZEJKLEIFIxB6gxYCkcHDdRHB55SXanZPWavsGpQDaX/NT4Ag4DUGp3v9KPpSB4Cxoua6NmWQc52pNytV8pM6+FdrhE9MEsssH4CIxwLs9857uF4+1ElAgEZosS+g213uVbHcAw9jogz7A7Eoec/onlEol77xt+hW40VLaMmTbYse72t5j12MjFKpuLPwVQWr0VI95Zy+C+tXzGCN7aWsMWxZ/TlDYX4LC+QGTCtMxng68AjuUy2VPVyoVj1nTNC/MYiIOtfA5S6xnw0S5pjWKau3784EI2IG7rq85/0QigT4Bi7r47YEW312DaX0YmAV+Rmau1WoIhUKo1+uIRCJoNBoeINv7otbnX6jNhaWBVqa+X9N1PcbMLKx5Flhzf9A0ukNnoVqtPs7n86cNehohNqaW991uF9FodG4zgD87aSjZlUUofQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAI5SURBVBgZpcE9SFVhAMfh33vue49X85ih1tUI0cXbF7QkCA5BQVAtbU3VUC3O0dbHWHNQUxE0NQYREUU0BoHUYB9qVJRdLe/V+6HnnPe8/4xu5NIQPo+RxEbYdw/2Txa6du0yJuAvEddmPmeuOgbErGf4pTFy7LVjjTUKSjvGb+eNMSDWCIzBrX4fLk9e+SwQLbmwS8rS+frc0/PAPdZYnFbxSVv87QZZkoOgC2MiCgMHGRi9GiIBHuQBYYLO4vv74xeBe6yxpCaQT8iSEHnhVz6RNsrU55+RL/SDUvAJkgMcUelCiPwgLRajgncrJE1Q0iCtLROVTlHo2QkYQIAHCRDGdkMWWFosaYBt30r3zjOABwnh8ckXXPUJ04u9fFgeZGGlSHtbnp5NdQbcFkOLJZWUreKbr1C2hLIaclV8WmG6UuRjeoDSUCd78jnmlxIqtZjZztN2N78FxEje4dMFfLKAT8r4pIzSBabqBxne1kElNswtZziTY/vWiObmsRwtlkQyZMgtIldFroqyJeSWqK8khGEeFzu8IHaiYHM4Wf6wSnzFNX90pPUwwkeBlAcfgXrpaMuTpBlpBs6LX2Sg2Wjwh9VqfG325vFRxCEMEetEI8P5WvFILmoPiTNhA8PcYop+vNWjSxOnDl95fMdI4l+uP/w41GY5uaUzvOwFy43Yu/KUGe/7ahozz2uzUy/PGUn8j/uXj54t9hev9Q3t637z4mHTSOJ/3Z0onegf3nvLe9duJLERPwFUpzZM2BWatgAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKfSURBVDjLpZPrS1NhHMf9O3bOdmwDCWREIYKEUHsVJBI7mg3FvCxL09290jZj2EyLMnJexkgpLbPUanNOberU5taUMnHZUULMvelCtWF0sW/n7MVMEiN64AsPD8/n83uucQDi/id/DBT4Dolypw/qsz0pTMbj/WHpiDgsdSUyUmeiPt2+V7SrIM+bSss8ySGdR4abQQv6lrui6VxsRonrGCS9VEjSQ9E7CtiqdOZ4UuTqnBHO1X7YXl6Daa4yGq7vWO1D40wVDtj4kWQbn94myPGkCDPdSesczE2sCZShwl8CzcwZ6NiUs6n2nYX99T1cnKqA2EKui6+TwphA5k4yqMayopU5mANV3lNQTBdCMVUA9VQh3GuDMHiVcLCS3J4jSLhCGmKCjBEx0xlshjXYhApfMZRP5CyYD+UkG08+xt+4wLVQZA1tzxthm2tEfD3JxARH7QkbD1ZuozaggdZbxK5kAIsf5qGaKMTY2lAU/rH5HW3PLsEwUYy+YCcERmIjJpDcpzb6l7th9KtQ69fi09ePUej9l7cx2DJbD7UrG3r3afQHOyCo+V3QQzE35pvQvnAZukk5zL5qRL59jsKbPzdheXoBZc4saFhBS6AO7V4zqCpiawuptwQG+UAa7Ct3UT0hh9p9EnXT5Vh6t4C22QaUDh6HwnECOmcO7K+6kW49DKqS2DrEZCtfuI+9GrNHg4fMHVSO5kE7nAPVkAxKBxcOzsajpS4Yh4ohUPPWKTUh3PaQEptIOr6BiJjcZXCwktaAGfrRIpwblqOV3YKdhfXOIvBLeREWpnd8ynsaSJoyESFphwTtfjN6X1jRO2+FxWtCWksqBApeiFIR9K6fiTpPiigDoadqCEag5YUFKl6Yrciw0VOlhOivv/Ff8wtn0KzlebrUYwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Ecuador",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALVSURBVBgZBcE7jBRlAADg79+dvb2929u9F8cbIeHhK8TeggiNHnbQaDS2xsICDXbGzt7KWEi0sLHQGEUiYhTQYEKEEDlCcrzUg4PjgL2dmZ3Z3bnx+8L80VfOzMzNHKxWqwAgAAAIAiBgWKx7+ODhL9HM3MzBzz85IVSC4foAAEFQKgWQDmIEZVlRrpdKhfePv3cwqlarCkNh8JXk9CVTZ1Irx3cYn2i6fv0P15LP3F3pmJhoub/aUY1q1pLMW/OlWlRVAeh0VnWeGbEWx9JTC+L4njiOhfySvNfVS7v6vVivFxtmiRDWEUQB0G5voBwYe3eaj/9SPzJrbvMWjcENveEeE5MTRqoVUW1EnGZCyBFUgKDT6YjjridzhbWpod7XixTryvScQR5Lu4lBnsqzRD9PhVCCCKDdnqMcmGy3dN5+1tSnq4YHNqvP5nb0V9Wa243Vq2ojNd20jzUCFQLIslwSpzprHd3xwuO9ZF/eVBaZSv+krBfr54ksia33EwEEUQA0GpOarUS71QK1N3ZqHDsvKp6yZeaqrNGztXlFfWRFv3dbtfKmgCgAup1EHOdIXFxa9s+gYuPuwr4T1y0dTsxc+FD8288eLz8SmmPW5xMBkRAEtCY3WRvmLqep2/2a6alpy4eCQyeH7py9Z7Rz3/7XP1Df9ZzelZ8snD9j95OmCpRl6c9/b/l+ccF/j1ZlWSaOE3Geu/B0qXb2d3sOHDF641fhi9eM3fzGzh1Tdj+6KgpIh4mVYqA+0jTeaMvyvuZoU/vvO7bdTS0NMqObdjF/DED00WatLBYRhFAxoaUXUvWiYSw0bbz2wMhSz60X96tcOC29/IPx796R95al6K5VxfUx0XBYKIrC1ukXbJ0hgCDswUvMhiA+klg4961tUw1Rtaa7MnR7pWpxcp/w6tHDP26Ym325WosQBEAAADyf3LL97kUTWSIeHbPY3uvscNOp/wGooE3b/ShD8gAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Azerbaijan",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIhSURBVDjLlZPrThNRFIWJicmJz6BWiYbIkYDEG0JbBiitDQgm0PuFXqSAtKXtpE2hNuoPTXwSnwtExd6w0pl2OtPlrphKLSXhx07OZM769qy19wwAGLhM1ddC184+d18QMzoq3lfsD3LZ7Y3XbE5DL6Atzuyilc5Ciyd7IHVfgNcDYTQ2tvDr5crn6uLSvX+Av2Lk36FFpSVENDe3OxDZu8apO5rROJDLo30+Nlvj5RnTlVNAKs1aCVFr7b4BPn6Cls21AWgEQlz2+Dl1h7IdA+i97A/geP65WhbmrnZZ0GIJpr6OqZqYAd5/gJpKox4Mg7pD2YoC2b0/54rJQuJZdm6Izcgma4TW1WZ0h+y8BfbyJMwBmSxkjw+VObNanp5h/adwGhaTXF4NWbLj9gEONyCmUZmd10pGgf1/vwcgOT3tUQE0DdicwIod2EmSbwsKE1P8QoDkcHPJ5YESjgBJkYQpIEZ2KEB51Y6y3ojvY+P8XEDN7uKS0w0ltA7QGCWHCxSWWpwyaCeLy0BkA7UXyyg8fIzDoWHeBaDN4tQdSvAVdU1Aok+nsNTipIEVnkywo/FHatVkBoIhnFisOBoZxcGtQd4B0GYJNZsDSiAEadUBCkstPtN3Avs2Msa+Dt9XfxoFSNYF/Bh9gP0bOqHLAm2WUF1YQskwrVFYPWkf3h1iXwbvqGfFPSGW9Eah8HSS9fuZDnS32f71m8KFY7xs/QZyu6TH2+2+FAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Syria",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALASURBVDjLdZPLS1tBFMaDf4D7LLqviy66aulSsnBRaDWLSqFgmvRBUhG7UDQoJBpiSGpKTQrRIIqvYBRMKJHeRuMzPq/GNAbFx8JHLwoKLZau7v16zlDTBuzAMAx3vt/5zjdzdQB0N821tTXz0tJSamFhIUXD/L9zRZutra2yjY2NUhKXkPj89PQUJycnGBsbO08kEiXxeLx0fHy87EYAiXtIrK6urirpdFo/NzenHB4e4uDgACRUYrGYnkDKyMiIOjAw0FMEyGQy9v39fVxcXGBvbw8kvpqentby+TxyuRwmJiY0El+RMyiKgsnJSXi9XnsBQFVbqFeNISzY3d0VoGsA77PZLBiwvLyMpqYmrb6+vqWohcXFRRcfXl9fx8rKCiRJQjgcRn9/PzsCtYXZ2VlR3ePxuAotEFGm6sczMzOXOzs7kGUZyWQSTqcz3djYaGhtbTX4/f70/Py8APF3n8936Xa7j9va2mQdidWzszNhlytTkBgaGkJ7e7vhukp3d7eBMgCdFc7YDYdrs9lUHd2xenR0JHrkD1yBEkdXV1cBEAwGDZFIRDjgFsitOG8ymVQdXYlMFo/7+vouNzc3BYRz6O3tTYdCIUMgEBAthKKdePvxGV52PsJTZ7n2+HX5d6PRKBdCJIsuClIExSs9JIyOjoLuHYGIB46oCZ9yQWS+SfB/seKJ/w7u2fQ+IY5Goy3Dw8Pa9va2EPN10cMSmTCoxlOB2Nf3iOU/gIcv+QL+5CsG/BKAwcFBOyfPL49AoHSvXC6XxqFx3w/td5HIhfHviGeDDPj7ph0OR09dXZ1qsViUhoYGPUEUdsIOHry5pXml53BLNULs/lxT7OB6EqDMarWWNjc3lxDwfGpqiv8DVFju/zT6buOdZBGVeeV9IYObZm1trbm6ujpVWVmZqqqqMtPhDpo/2PaftYPP/QZledsx50IwXwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Poland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIjSURBVDjLpZNNaBNBFMffJNumS61t1cRYUYwGvHgRj+pNUYmkh54UPFnEgrESaA0oloKC1UuEKmoRD6HgoSIRK1ooUhUMoYpaBWvS9IvmUCMFYbs7Xzu+bU2s9kOwC392Zva937z57xuilILVPK5/BbSkmtzR16di/w0QXNzhlB9f7jtZ6QjNA41xf8WmZoTAyHTuG6fsLbX4c2axh4+b+iZXBJx9cfLyxgr/hR01QZC2BIMZUPjxHfKFPAyPfk0ipGPgYuqNtlTy+cR4iG1g5czFgEkGM+YMaO5y0DwabNu8HUCR+vS7Qdgd3RVZ5EFrYlyX0o7fPpJozeazne9HP4BlUchMZIDimwoK671eqPPX1VOTNiyqAJNbUEFn3H3sUeRo54E1Q8Of9mDJ/Xj+hv17921xKqmurQFG+aE/ANH7uYC0VQwBpTXTsBoxOfaqLX0FS4anvc/OcSZAoKSQh8ExsahIVybZ0TOmTt/6opx5zyBLogILY/5WyYNIVza0rtIdLiP4739XELYVfH6QZpe6U0xftpHO3M2gcTLuwZlhyRIAk2Gnj+i+KtIupPp476UVWhLgGOerKgtyboPFbCh6gH7MQao9BLbWkuBanTy52W8mb/TNBooADc87Zxx2FJiYjDstAAAwoXANwO0i4K0kzo7hsYI4eK3XuIp51zUsN44DPTc9+2tHlD3fnQ5saAqh9vy4KATrGNuOYSfIaq/zT68cX09iiVY0AAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Philippines",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAABjSURBVCjPY/zPgB8wMVCqgAVElP//x/AHDH+D4S8w/sWwl5GBgfE/MSYU/Ifphej8xbCLEaaAOBNS/yPbjIC3iHZD5P9faHqvk+gGbzQTYD76TLQbbP//hOqE6f5AvBsIRhYAysRMHy5Vf6kAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKOSURBVDjLhZNPTBNBFMa/3e0/ty1tiZUChkZAESnGA54k4WRATQxJL2piYpR4UBNvnrwZPXjwiiHRBCVBUMJJ0UrlYtJEjI2JBCkEbLGhWGxh2+5u6W7XmY1LCkJ8ybcz+2bm9968mWE0TUM4HLaS9jzRxXK5fJS0h4lIt/yNtAukfUIU7u3tVbHDmMnJyWNk0rDX6z3u8/lgt9vB8zwoeGNjA7lcDolEAul0+iPxXQgGg8lthFAoNBWPx2k4bS8rlUpaNBrVRkZGBim4Uiz5tNXU1OB/Vl9fDxLkzE6/iTh10urqKmw2G6xWK8xms+4TRRGZTAbJZBJNTU0UgD0BJpMJ2WwWsizr/4qiQBAEFItFfYz6dgOwxl44jtMzcDgc8Hg8cLvdejEtFgtYlkVZVdFQnLInXnVPz/cHrm0BjAxoRFIsXSqZTGX4aL+0MI62didf13Ovw9kcePjlwZGebVswFlDRbPRFf4Gu/DQc3nm4Wk6jEJ+A2dlS7W4ojk3cbuzbAlRGNwBGBryyBFf7OajiDGz7D0JWf6K26wSvFLL9OoDKiG4AKzMT1SqUsj/Acmtg2AIsVWuALCK/UuRMdAI9KnITkUqlIEnSVoUt8jICmMK+WlJEJUMKtk6q5oRW2sT3F3PyzJxwnWZwJRKJjLa2ttr9fr9+DxiGgbj4Frz0Hgc6OqFthsCoOcy8FiRTbkXgyHhsUbh5eXhpjKFpDg0NHSKgu0RBcmQuenxt2jgaO7uxudZP7oELsx/y0udI6pZfll7a7By6BhM5/TFRQKUNDAw4SS2az/rePKvrPBVQ1iOYffc7/zX668bVp/PP/3mNOwGGfXp08r6j2tMnZgpSLJa+c+lxbHS3eX8A58zTPyvL4X4AAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJ8SURBVDjLpZNLaFwFFIa/O8m0lTxm2hJHU61Omuk0M2o1aBOl1a3QkKXQlWRhXImCGxWkCxVCobhQcGFwJeJKKIgQQSFqrWBS0zRFE2xTOiZpHpMmITNzc+95dBHQlKTZeDYHDvwf5/GfwN35P1G/U/GDsXcnzLSoaq6q333U/XHP/QCJ7eJ3DmAU8415cs25QFS7d+tgG+D9pweWI4kqscdUogoiMr4bIHB3PrzynpspqoZuZu/YfywQE67Mja+KqKpqQkQY7P1y/7YdqClHG3KYG+aOY4Ga4Q6FlkJKXXE31qeHmfzqjNc1PkllaZggnHl1E6CKumFuzK7fYiVcQVwwdxJBHWbOS3uhK/0ED7SfIpV9hpXpPH99P3huEyDKxNIEzckUmYZWFqtLqOvmOL7BUVngZEsXTY88y/L1P9kTRDQ1P0TjwcOpYKsP3vrxdS+0FJgoj6FmmCuP2x1ea+0k3fYyG3NfUysHLExWWQ1DErVq/p4riCjqiqgiJhyOy/Q/fJz0kdOEs58TJO+QbGyCqMSn1X947o1vpuoB3vyh30WU9L40akbsMa3lefqOnCDV3ks48xmJpBCtZSkNX+J8HFEy++8KIkox04HiTK/doCtq4Pl0Jw8WTxPdHqRujxOuPsbsT79RX6tmv3j70s17jBSLICh/LIyQnVnnhSCD+qPMXf0EI6SyfIhbF0c5G4fkt4j/BUgsqBnFg0+RKc1SONnP3tIvTF24yNjQMqNDPzOUzXFbbednEhF+nxpBVKlenye69i3Z46dYXSzz9+VrXMgdsrmrl2tqurajlbfGKy8eqHW2ZepPdGTx5MavtYXFvp6B8Rv3+4W77h1o9knDsw0AAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Jamaica",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKkSURBVDjLpZPdT5JhGMb9W+BPaK3matVqndXWOOigA6fmJ9DUcrUMlrN0mNMsKTUznQpq6pyKAm8CIogmypcg8GIiX8rHRHjhVbPt6o01nMvZWge/k3vP9duuZ/edAyDnf/hjoCMP2Vr3gUDj3CdV6zT1xZ6iFDaKnLEkBFOmPfaZArWT5sw60iFP+BAbOzTcQSqDZzsNRyCNkcVoaGghzDlVQKylOHJrMrUZ2Yf52y6kc36IxpyoH1lHF7EBgyMKV4jCJ5U/1UVscU4IZOYEa3I1HtwI01hwxlDLhDoJD/wxGr5YGmOLAdRIrVCuhmD3JdA6SQabx12srGB0KSpc86ew4olDOGjH4x4z0gdHDD9+c4TaQQtq+k2Yt0egXYugTmoVZgV9cyHSxXTtJjZR3WNCVfcK/NE0ppYDUNu2QTMCtS0IbrsOrVMOWL27eNJtJLOCDoWXdgeTEEosqPxoBK/TwDzWY9rowy51gJ1dGr2zLpS2aVH5QQ+Hbw88sZ7OClrGXbQrkMTTAQu4HXqUv9eh7J0OSfo7tiIU+GItilpUuM/AF2tg98eR36Q+FryQ2kjbVhximQu8dgPKxPMoeTuH4tfqDIWvCBQ2KlDQKEe9dBlGTwR36+THFZg+QoUxAL0jgsoOQzYYS+wjskcjTzSToVAkA7Hqg4Spc6tm4vgT+eIFVvmb+eCSMwLlih/cNg0KmpRoGzdl+BXOb5jAsMYNjSWAm9VjwesPR1knFilPNMu510CkdPZtqK1BvJQsoaRZjqLGaTzv1UNp9EJl9uNqxefU5QdDnFNX+Y5Qxrn9bDLUR6zjqzsMizeWYdG5gy6ZDbk8aehiuYRz5jHdeDTKvlY1IrhSMUxe4g9SuVwpdaFsgDxf2i84V9zH/us1/is/AdevBaK9Tb3EAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAFlSURBVBgZpcGxTpNhGIbh+20+DUkTRhkcNLBIOmG6+Q+egg4cgWExhDi5sDm5SErCoB4BDB4KjnVTBpooCTKUOvx9n4d+ISQOQNL0usI2i4hX7w7fNi/7H88n7tqAhCVSiWVk4Uxk40xSYvlhezkcnr7/9mnzoPRf9PcfLHU7K0vMo3s5yX3goExadybnY+b1r3WHmeI0u68fM6/twQlVsYVtTGUwEMH342Pu8nxjg1RSFWwyk63BL2583XlK1TQNtxmPx2iaVCWVyObz9hMIgwPZ3EcSSlEVyyhFBFjMGML0ej0uLv5i858ATABSUhUpkRJzLZgxDH8Mucuz9XUkUZVp25KZ7Hz5zY3B1gpV0zTc5uzsD9N2SlWcQhJ7bx4BppLEfTKFJaoiCcmACMBcW11dYzQaAQFhgsCGCIMD2VTl9OfJ0YfDdlOZKEVmIolsWyQhGytxGllYQqI6YiZss4gOC7oC3Q3wOtNMt7AAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Honduras",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIvSURBVDjLpdNdSFNhHMdx6YVIhaALC8GLoFcso5dVRHVRFFQISlJeVFYQgdKKiEprldrmS8KgWYK2raZGbaOcafamLVxq6qxs5qxIHYpkUiYsmVvn2zmnGBbkhbv48Ryeh//n+Z/D/4QBYaHkvweagxujb6cttzlOLuqtP7Wgx3I0tjr38Gp9TnIMYu6L2TEh8DkjQhgzJSL0tSC4rAR0K+i8EId/9BtPLq2RERnQ7Fs7xZs/4643b/qYN3caXrWY7KkEGnQw2AkjA9DnhN5G7FU38DzVUHYiTgIOyUBByqqI0ZyZ9bSUgNMIzeL6/iF4mqDrAQy8+b3fdJUipYK+51q0KfMkIFoG9EeWLfRlRrbLQFkilCZAbSa0ikU9DvHmF+KznmHzcZ81XcGHe0qpmOBHtB2bn+BXz/HQoofyJLi1B+qy4FU59Iutd9WIXRXTWaEbthdsprtG9TfgzJirFhza7zxWgXkvWPbDMzW8NcPXbvhYC+5qWiv1vDPtpvHKNglwBYEvmshK8YaA3LphOzw6B+134JOdQKvx54gx6YfPGO9/XZ4uAxXn10tAdhAYzY94KTQWQlupGBNCRyW+QgVDqkih7fJOp79em9x/84BhZUwULsMuilNjJWBTELAol5R0qKK8Q1nhwmBmuOA+PdtnTl3cMH4mxIIt19OWyh2Mf/8JB+kfIM92cUNIgLu5KD4kQC6uK9gaHOFJAdaz6yTgzGSAa3/+QmmdNf7sF2A4ynPOLQFtAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Japan",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAILSURBVDjLjZPNS5RRFIef+753ypJEs4UJftOmImosSGgREn0tBBdRLV2EGLooCIoWbSL8C2rdQmwXGBUzQmkx4LIPaJLSQiYtRkyz0Xln7j2nhShKOnjgcrgHznN/93ygqmznzLS16WbxgG3as66uTeNGVdcu6XRavfc451j1zjmy2SypVIra2lpaWlro6Ogwqzl2Pa1YLNLc3AzAerCq0t7ejqqSSCQ2KNgAcM4B8Hp85WdewQuICt7D+YOOKIq2BhQKBVSVeM3vTQsJldsDjGWqEBWcrChwHkSUzqOOfD5fGgBwYv/sFu2sKq0giiJUldHve/GqOAHxK7VQUS4fL5ZWsODnUVVO1WX/ez33ZpDxJ4OcnPpKcvTeFPDwbNL1rwFujfU07qgs44JeREQYGBggCAKMMTTMvudIbIb4pWvsbDrE8odk3ae3w/eHz8Rya5MoIk1BLCS98BFVxVpLPB6ntbWVyokRDpzupGxiBPP4Krsnn9LYUB2q0RsBwM1UdwXevKqO7WM48xIRwVqLtZYgCNiVm6espgn6hqB/Du5MYnOfCcU0WgDvfI93ol/+jpvyQgWJzAskJoRhiDGG5fI9LL17TvnQdaLlnywBi39CfMi0UVV6e3u11CIdXkpzLMxQX13EBhkWs45vvywuL3c3LFMpS12pv52bm+4OvWnwof5QeHQu6R78A6o+ZiAxKKNtAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Albania",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJ8SURBVDjLpZNLTBNRFIb/edgWamkLsylqsaASIDUEBHfCBqohcWG6UIM7YmJMNG5cuKkudGEMYQeJYqMbCZGFYVHrStMYTIm1RU3amsgjQVQaHsXSztt7p7YqlpWT3JyZO+f/zn/OnWF0Xcf/XPzOjVgsFlQUZVCWZZ5EkGgsSZJonPD7/ecqAhKJhJ0IHjgcDr/ZXA2RiKBpMPwRl06nA+Fw6Cx5+hcQj8dPUrEgCPusVivmF5ZBq2uaDk3XCEiHSmCiKFZugSSH3G63sZHPFyAT8fvEWwLQyquv/5TRRkUA7dFkMiGbzRYrqypa29qN6vqv6nTYuzqgZJWIaBI9FGo9EZ8lUTWq03eugdM4xEax9NQ3K64ujx2+9GH8LwfFWelGMgW0eTuM6iUXzOI0jncLsLdeOZaZGb4bu3NkueNG+nnZQQlgQEhlKqL3qzXz+JJ6jI6D+2Fv7kNuMYQ9tuZah1ucCl1tHGJLgLJY/T04CnqYuo8GpQC7dwDq9idYhHrw1YCrp726qdU9ajigwyl9kdQybUGnELJ3re4mhM0w5PUFsFwGDJuDqSYDFLbxY0Xkyi3QU+A4rti3SqeuwSQu4YD2EuZaAla+g9U2ANYGXZaQnEgVPqayF0sOopFIpNvj8cBms8FStQk+8xp1+Tdo6PVBl16AUbcwN70Fc27lG8cwSH/OXr7wZH6KKVkfGRkZIKdxy+VydXoam1C/No76zhOQMqPgeTuSr2RMRqvQm31XY7Fy6Hm0tEV1zM6/MRAI9BPQvTMtSe9RXxeUjRnMhdbxbM6Br5qQDAaDLX/mM7v9ztHhrtt7a51D22u5fDq9ev38WHqyUt5PJr6PrWVr/2QAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAH0SURBVBgZpcFPaM9xHMfx5/vz/Ywfv6ZwGC1mtRsXtRvFQSmlKK3JkRJymAul5EJcrFZrcnO0QpELDgrlKJcd5M9PtpHawew39v2+3y/7rlZuLI+HSeJ/2OGhO2d27+2/PtNWUwIiUAQejkKEArkTEnLHI1i3qpybmJg8f+/GwGju39U/0tFopq4GK9Gca/sIMJrbpVJ75gcrNV8qsSjLxZVjfazUiWstalkKaguVI0AhPCAQEcIj8Ep4JVzBgoveTZ14OLWMRM2SYRJKhkxYGCkZZgkzxwpRRCJXohaVU8seTi0BMgODQhAGEaIQJCvIBm7CU1ALD2pZIZaYgUQCZAYGZiAXYSADklFEQS3CqeUIZ5mZsUQiATIjspEjmHp4k+mHY7Q/vaWjq5sdq/cAB8lVWbLEDAMkYWaIRRIJmH50i9lX4+w8cpzVvduZf/OYNc+f8mRfx9kkD2oFYICZYYAByYxkRuvuMH17DtF49wy7fZS17+/T27MBmYZyRLDMAGORGX9amGrR2NQLB86xLF/eTBG2LU9+aI2fGi4Hwp3wwN2JCLwsiQhCYqCxnvbrRzQfnObX/BfawOz3Ai+YMkn8zYvB7surOpsXt2ysck6fmf1W8fFr4eVPXTJJ/IuXg1svzM1MnSzcerzQpGBs/+Pq6m9gRhRi/EsJnAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIwSURBVDjLhZHLaxNRGMUjaRDBjQtBxAdZFEQE/wEFUaurLm1FfEGzENwpturG6qIFrYUKXbUudOODNqIiTWqvFEwXKo1UUVRqS2NM0kmaZPKYPKbJ8XzTiUQxceDH3HvnO+e73xnH8X7fLjJInjbgEekiOwA4/sbBD0Ov5sIqY5SVXiO/Rpospw01HphXrOttZPBMxCkWJ3NltZItq3i2pOKZklrWi9Z5SMuKwf2GBtJVxJotiqWLKpIqqHCyYO3/Z/A8UyirBDtLcZTi6Y+RdxdHAsnTAy/NM0TerCuRlE2Y9El+YjCWoLBkViyxdL40OpNmLuBo0Gvk12AuYC5gLqB2XAw8A2NBFZzXVHm1YnHq1qQpYs4PjgbmAuYC5gLe0jrnWGLwzZqDi33ksSTunw3JvKZ0FbFmi5gLeDswF2v/h4Ftcm8yaIl9JMtcwFys4midOJQwEOX6ZyInBos18QYJk0yQVhJjLiiald/iTw+GMHN2N6YOuTB9YieCozfE4EvNYDO5Ttz2vn/Q+x5zC3EwEyw9GcaH7v0ovLiN6mcf8g8v4O35vRg+edTr+Ne/tU2OEV03SvB3uGFQjDvtQM8moM+N+M0D8B92LjQ0sE2+MhdMHXShOutF/ZO6toXnLdVm4o1yA1KYOLI+lrvbBVBU7HYgSZbOOeFvc4abGWwjXrLndefW3jeeVjPS44Z2xYXvnnVQ7S2rvjbn1aYj1BPo3H6ZHRfl2nz/ELGc/wJRo/MQHUFwBgAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKJSURBVDjLnZPfS5NRGMffq/6BIMhuuvRGKLqooItuugiCoi4qiNDoh2RS6BCnkA6mG+3dD0bvHDXB0iTtwm1M4X39sQ0ZqAzJJYGUNWFuMje3vdtSW9u38xxaDOvKA9/3cA7P93Oe9znPEVwul8XpdN4CIBxGwsDAQL3dbp8zm80NhwLQx2Qyafr7+8O9vb3HDgXQ6/VHenp6ZrRa7Vx7e/tR2ltYWDDMz89X/H5/RVGUvcnJSb/b7b7wXwApEAi0tLW1bVksli/BYDDEzD/YACkT8OO7x42xsbG9kZER7T+ASCQiLy8v/1paWtoLhULY3t5GPp/HVlrFuhzEtzOnuJLTCgYHByus6G/+AlZWVsSNjQ1+0vMpLTeqqopEKofG9xXceQcEX3mQcEjIJpM8bnZ2FqIoGjiALYpkymazHFBVJpPBZjKLaCKHXC6HQqHARXCK7evrK7OiXxdYcSoEOGiuKhqNgmUJq9VaIe3s7PAs19bW0NXV9VWYmJgoE7VqqALS6TRkWYbP5wOLQbf52c+nL2/vP7RcRdOLy3grS9BoNBDGx8fz8Xicp0VGSjeVSmFxcRFer5cqj06xFboPTfCtSvgYV2Cdfoyb1gZca70IYXR0dJoqT0YCkNnhcMQ6OjrU5uZmMKl3DZfKnk82eD7bQUOceQDrzCOca6krCcPDw510Et0EAeh3WHvna+/6SvdpTK26UDu8EQlnW45DGBoaOsnuNR8OhxGLxVAsFmGz2cq1gPNPTuyalHswKI3cbJAbeQYMsMsDJEl6zdoUrJnAmgrsXezXAlig/oZYD7Nyn59MM63ZvsgD2GusY42xbjQaS+x+SzqdLnSw51mwkUmltP/MRtr/DeMW8yghqDBkAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Iraq",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJXSURBVDjLlZDhS1NhFIeF/oJBEK5ISiIJsaxkTAQTR8wSacY0xdlmbZqkTZ3cmmKprU3naltOd2u5UtFSAiuSaAUVGEKDvphtXuVu79xttfB7Ef16FwRhG+mH8+H9Hc7zPuekAUj7u9omQ2ieIGj0hqB1B76s76+vf4KmCeFh3wzBxekYVGykYdMALbsEtZsfrR+NQ+mK5m8KUOchUNk/vqlk41srB6MosxLDhgHqkdhAw/AilKb3/YrO+cKqQQK5OTS2IYDKE9uvcQZQ3u0vSrz1r7T3au/3obh3Zf6/gGp3dEjpJFCYPuC4Tdimf33Wa39ngfVtLxS3ulHuKdkid1RFi52EOWInvgIb8eVbyZTUHNYlPWLj89M2y9wVzC7PoPNZO446rn8/NrQKzVgMBVaCmhEBFx58RgW7igM9vC6pVvWkot842wL73CyUtwVox2OQ9hFLopd3lbdovAJOuaPY17HCpNytxFH0rfXxC9TejUHS8/JnnokXJfKcLp7VUIsyZxh7GE6XajhaaJJCYszFQeNl5Fxy/aC6vuwuHiecEVx7EkcWs4yMVk6U0kBiDouorq+Cqp50/db172W4qTN3BDTRlXbqg/6kR/xTuT28v4oVoBxeRVYHxySyXQaOKR0Io8QaxvbzASYlgOrKZDYCy9OvyDYuI9PAiajubvrrSsu4gMM0E9cHZCkBVFdXeiOM3kdxlDkiyGxbQpZhCXJLCPrRT6i5GcGhdg7iukVZUgC9rojqshn6IHY0BxO6fvG5AEN/ZcTaxTU6uJZet8CmqxdEvwDWpa/ASC8BSAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAI2SURBVDjLpVNNaBNBFP42aZNqXEw1iv0xFUpBLWmrF0v1IpKiKOohBwUvhYDgz0G8eIugYBBFD+JBpV49ekqpHoQklGBpzNb0UIwkoFarIvnT5m9mfDPJhlJTEVx4vN3Z9/28eTOaEAL/87StXYjH409rtdq5arXaRhmUVVQqFZmf+Xy+sy0JDMPYTIAnTqfTZ7dvRJlA4BzKH7ns7HRienrqDH39SZBIJI5KsMvl6nE4HEhnPkGqcy7ABSciAUZk5XK5dQtUPOV2u9XCykoJVQK/NeaIgDfDO35MtdGSQPZos9mQz+fryoxh7+CIUhcNdbnZ6zqQzIxAskgORVo3ErOUmVKX/7qOn/q7g/peCVUsCQY9+5W66UKsswcW04FJoEikMqv3/k1PYzJ7H3xVXcsWmuAG0FSfXHyMn4UaEpkwcttSOH/vtCj8yhWyxR+3Q7eMm4pAWjNPpATxhmVOa1e2XsciZpEpxeA9fBC9WwbwauG5HktGboxe6nY2W5BTsFqtdWXGV41QIPk5jJHdw2AWhuEuL5hWxahnTEIvWhoOXkciERSLRei6jo4NdjqBmiJi5OJ7YRnt2iac3HNZubx65BH6tw/J1w5F4Pf7D6RSqROhUGguGg3DbtOwq68XbncP+nZ2I1/MYmFpBsGXE4og+GIC77/Oy9eStvY2BgKBcRrrHQqPeZk+8CTa+5cxNnQIAzv24d2XN5iZj+JjOndX+9frTBsWpHSBQqcoUDyMPVi69hviC4VQKCIpUgAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIpSURBVDjLjZNPSFRRFMZ/9707o0SOOshM0x/JFtUmisKBooVEEUThsgi3KS0CN0G2lagWEYkSUdsRWgSFG9sVFAW1EIwQqRZiiDOZY804b967954249hUpB98y/PjO5zzKREBQCm1E0gDPv9XHpgTEQeAiFCDHAmCoBhFkTXGyL8cBIGMjo7eA3YDnog0ALJRFNlSqSTlcrnulZUVWV5elsXFRTHGyMLCgoyNjdUhanCyV9ayOSeIdTgnOCtY43DWYY3j9ulxkskkYRjinCOXy40MDAzcZXCyVzZS38MeKRQKf60EZPXSXInL9y+wLZMkCMs0RR28mJ2grSWJEo+lH9/IpNPE43GKxSLOOYwxpFIpAPTWjiaOtZ+gLdFKlJlD8u00xWP8lO/M5+e5efEB18b70VqjlMJai++vH8qLqoa+nn4+fJmiNNPCvMzQnIjzZuo1V88Ns3/HAcKKwfd9tNZorYnFYuuAMLDMfJ3m+fQznr7L0Vk9zGpLmezB4zx++YggqhAFEZ7n4ft+HVQHVMoB5++cJNWaRrQwMjHM9qCLTFcnJJq59WSIMLAopQDwfR/P8+oAbaqWK2eGSGxpxVrDnvQ+3s++4tPnj4SewYscUdUgIiilcM41/uXZG9kNz9h9aa+EYdjg+hnDwHDq+iGsaXwcZ6XhsdZW+FOqFk0B3caYt4Bic3Ja66NerVACOGttBXCbGbbWrgJW/VbnXbU6e5tMYIH8L54Xq0cq018+AAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Russia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAInSURBVDjLpZNBSJRBFMd/37papinFUgZmYESIFiGRYdQhynueig4eomNE0NmDidc8du7arUNFKJSpIKQHAwlNKkUzTVdd3W++mTfzOuxK2RoEzeENPHi//3/mvRepKv9z0gD65aVK7geqFhWHeoeKRSVBfQLO4MWgEoMz1HY+jXYDvFDecrOErgoRFAOgkH12q9RBsr5ApSoa4kI2AtUARCi/CFFqH+riPZ4gQrBLSG4MQoKqLdzBQjBoMGiIqcjcILj8HgCfAIIGA+qKRb8XGzTkQQW1eziQrdWC5V3KMSGYIiSGEBdEZLsUELzBzLxDkk/gLajgzSb7TxwpKAdDz8QUWfOAR3/8QQrAx6vI5gLVTbepbuniwOlrEBzq8xDyqM9jxFKfaeJ+ZXmpg0gVtzxJdmCYmva7RFFEz/c5WJrFBsGKcOzQKZrq2siZbTr665wRWzH0cE3TO/0+2NbF2kA360OPqb1yDwmW681deA344AkoixvznKm/xJaN0+Nzb+3Z3lRFGgAxRGUpqlrvEE+9IDf6HCMWr4GvqzO4IEhwOO/YTHKcO36ZLZdPj30eNsU5MGRf9aNiUBdj4w+Y2irEC0drGpDg8Rr4tjHH4eo6JuZHGJkd/miF1uhvy9T5pNEba7HBYsRyMtOcutjYwfu5UQanX09a4cJinybRv25jS29q5XzD1cyb6cFxG2hf7FNbbMC/ARq7oxUfyjJx8OXLfSo7+Z9JyXr5I2wfSAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Ukraine",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJpSURBVDjLfVLPTxNREP52C+mvbSKE2FYkkIiJioo9KMT0QKImnAwHPXjk1IPoxUsPaoiaSDw0MTEe/Cs4mWhVLGCDlWgwFCMJiYeCSGstu9ttt/vLeS9dLBCc5MvMezvzzcz3VnAcB8ys2xMOTp2GmU7DMU04lgXbMGA3ffvoKJw37xF8+0pAi7W5QWuR01Jos3vXNwzstX8EhslJbF3nyZyI+WbcdgCBuENAHx0qRm8vLEZCYN6q1yH098PWapTT+M8EDeNBvV6/X752HWpIQt3jgcFGVxT4Sr8RnplFiHIOJFi7d7fgaJra2d0t+ehs2zZcgYkYnz0eVbs8Urixh0BgSSsrK0OmaU6Hw+GIQh1rtRonYBBFEV6vlyOTyWzquj6WSCQ+7tKARk12dXVFZFmGpmmw6AUYGAFbQ1VVfh+LxSI0TXKfiJQUZ5OwziZTvdmdwSWrVqsIBoOgCeL7Vshms1ZPT49YLBZ5EVo0cM/5nzl8L36BrFWgaNtKRS0/efl46REXsUHP4ya3ejdeWs+iJH7DSPwCjnYex0x+OrSwPPdweOLIIb4CjVXe+aWbu7vjM//pxzucOzEIS7QwGL0CSzAwfOYiS7/pEsyz/ZnSbtdWlORfaBckXD15ize5c+kFjh0+y0Kf2HznqcXFxU2fz4dAILBLA0EQIKsV5DeymEqP829Tr8extvWVl3omJycxMDCwnsvl5NXV1fPRaFTq6OiAJElcdb/fj4r8h3SYRV+4DyWtgO3qFj4szUGu6E8Fd3dmqVRqiNZJkqhxQicTl564TJhfRlrRBXWM0kIEhfB84dlG8i8v6tBqmkd4owAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Philippines",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHoSURBVDjLpVM9awJBEB2DKIoocoI2goXVgVhoYam9bep0XqX+DU1pZ6EhpZ2FYGsnot2BqJUgaiGCd/j9tZlZvc2ZjyZZGPZmb+bNe49dC2MM/rOsXw9Go1EcQdMYSYwIDbheryruLdwb0Wi0Z663mBlgs4J5TpIk2el0gt1u5+f7/R7W6zXMZrM+gpRisVhZNBEAxXA4VAaDgYbFjBbtuq4zTdPYbrfjZ5vNhnU6Ha3dbitGH2dwp/0eCoVkmrparQSweYjP54PtdgvdbpeYvKRSqd4TFWCSJtpGc6FQgEqlKpqLxVeoVt8AGQFJCwaDMrJJCxPJMPpBWhEMboPZ/ZvxbwMMG8Hr9VJtks4MBhGafjgcHigbAIRhnBGAy+WC8/kcEQBmrdR0+3402VxzPB7hdDqBmYFK5thstjsAExI+81szSV0ulwSgCoDL5dIigxwOBy+SJN+DBHLfYEE10+mUJLSEiai9MR6Pn1Gb7Pf7QVEy4p7QBcpkbrnb7Yb5fA6qqvYxbQgGiUSih66W8JLoRM/j8YDVauWm0k5BzXgTodls6uhBCUF7365yvV5XUFsuHA7LgUCAA6E8WCwWMJlM+GTMS/l8vvzjW6BVq9XiSDuNQPwxoVZuMkYLmTSy2ezvj+kv6wM24KX3CYk6PAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAL0SURBVDjLhZNbSNNhGMb/EqGGUEEUUhgWUkmWQpFZ1oUkdZNQhFAeMkktQY288EgeKk+l05zHdI41tZNO5mHTEJ3OmTrPh8imTvM0tTxs6qbb07c/OTSjLp7v4uV9frzw8aMGWI9MSAJI+CQyEiWJtiv7AZoZbqh9fl3LD7+sLA46Lcv3seQz3fcFpLiamQCg9KHIcuNIVRwmmphQdORhtoeNma4CTLXkYlyUgdHqFMjK4tDLCUUjwwslIZdAAI0GQD8nrGsDMC3NJXmNSUk2vtczMSJIhoyXgIGiaHTkPobohTsNYLibdxkA4m65tVRch29VOegrjEQL0xu1cS4gZ4OcDZbvUWR5WyDH/ySKYm8iJz0e6dwqawNA/9QOagTSMTVml9awotFhdU2HOdU6+iZW0CZfxvCsGrIZNcrbZ5BeOSzYKBsA+gj7l0uF/SrdCFlWrmoxMb+GgclVDJGi+OsiMoWjulcVwyWby1sA+vA6FuzLOuZln2VLGP2hocuVnXPIEMoH0yqG7P8sbwNspLBJ0dAuV6JteAlMgVykn/lzzqnus+zgmWdj+l9AcdO0pHNMCSkBpJUPNehn3iw7VTT/NlyzjsOFedj0r4BC8bQDr1Uh7x5dQiDXEQFvzsOPfQZeebaIKL2Fd62pCH7vgispB7SOSXvNtgA4DVO8D83TuiHFCv0T5GTw2jPwUZpOF4tbGWB8CgZbkgg/rjPOxhlrbWKNdtPlAtGksKZnDuPzGqjUWmjWdSAn0+Xk6kAkCPzxrNIHUXwvxFT4IksUC7eCi7B6Qq1TRTU91tyGCdT1/4RicY0ua3XAndwTeNvCALf5JdhNicgXxxPIQ2SKYuDDvQrLSEpxMJSypV3oFWahUSKG5MssxmaWsaDS4EbmEVxLPQSnlP24kLQHHiwHZNRH4R7HGcfCjNTmoZT1Npn+5YLd053wZDvhVLgxQjx2STfbaNCZKCwjCit/K0y7QBTWEoWVVhGUziJ8B4LumkZv1vkXO/PSRSy+XJ4AAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALDSURBVDjLpZNLTBNRFIb/6RMqtEDBFopFXiFGIERYmKgJUXBFQly4gI1LXbghcYPiI/JYmbhxLQvC3hjjQkSL4SnvYCRUCNJCSwSq0OnMdObeud6ZBIzB6MJJTiZz7/m/c89/5gqMMfzPY/tXwkYkUmkRhOuU0nJCyKvs7OyXPp+PHu4LfzvBSjh83+PxPM5wOs1vSZKQTCbjsizX1NXV7ZmLBuBPMbOw0LsVjzNVVZmiKIwLGQewRCLB5ufnv49NTGQYeZY/VQ6Nj/d5vd67BV4vOAC8IjjEqA673Y4stzuHi28buccAoVCoJ+D3dwZ8PqTTaRPAewf3wHwfHBwgx+OBRkjnMcDq4GB3FaX3TrvdZkVDfCg0QtM0c52birSm5f0G2O7q6vY7HF0FNhtofz/02VlTbIgM8ZORdvS+v4bME04kRRGpVCp8BFhtb7+ZUVralcF7JpOTIJEIhIEBYGjoV2Wiojj/DDpeNOHT8hJSothkjnEsGHT6W1qUYGsrtOlpkFgMOh/Xw+Y1MKpCZRQqhxTlVaK2+CI+fn2Hxc0pppC0+8OdhGhLWq0lRQ4HGDeHRKPQueOUB9FVNFffAGU6qE6hgyG2H0VN8QWIqizMRkb2a3ssebYfsqzK8Tj0RAKU93YIMI5siDf2vkDTuYm6Bo1qOEgnUXfqEkRNskytj+5ZdkRxI7y4uJRcXmb2wkLQVMoMhSgglMDnDsLvLkGhpwx2ayYKsgOYi45hbG10R1LRYP7Kz3Jz8+srKuYqq6r8mYzZpc1N3GqLQuFjVHkrMlFZef5Z4XzZVcxExjEcfrOtElyJ9bHPR3fhaVZW7kmX6/m5QKDRIwhuhRsZkyQ9Kkmtbbu7r6t7LKmG4GVXKDy8peqmeOXYZXrkcAgeq7U+02JppIytqbr+tkNRksZe2QMhRXWrS9Zp2bc+tn6o+QkxLL87j8znVAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Czech Republic",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIdSURBVDjLpVNLa1NREP7uzb2hkSR2Yc2jxtKg2BYExY2C2RTBRXHfPyAu/ANZunYjLt24ElToShddiC1dSNWVSCE1bSJqsOTRxvTmvs/DOSdaQVexA8PMuWfuN/N9wzGklDiOmTimWb+Ter1+J47jB+QhmRcEgeP7fpf8g+d5HYoDijvkr6rVKvsHgAoe0o8gr1YqlUdjTzAcDm3qukpAz8ehYGw02TeKZ9yddRAAJhdugnMBpp0jZhws5ogoxrE6Mx2jUd5SADJnOUeIaitqMUK5kPrMKapcfeNC6JzwsVE7+LOFc8UMWh0X56ez+NJ2MFfK4vP3AQa+h2avj609H439GP0gxkIppSeMIgZjfTeiCYZodV2NrC5UR0Zumgx26iQuFNOw7AQ6gwh9J4QtfXBm4PXHLkzGRiMtXi7gxpUicRVYulpCGBFHM41y7gT6oYG9Q9LCSGD6dAZdZ6SR0sPSIlkSLze/gjHVWeDpWoMKJAI/QjJpg4VM8w/pfsJKgEmLhGZUz38BUNdb187i2VoTy4vlI0FX3rZHanNoSlpkA/BcF+lMUk9hRTEh2QLvtnuYyWfwZqutFRY0SRIcjs+RSSUR0kSWSVQOYsj9TzAdh2pmYIUR69Vceeqv/epcibnbDjBbyGoKh24I1q7h+lQHPxqbyDnzjjHua3xxb+l2vpC/PzV7aXL7/apn/M9zfnJ3brlQvvhYCJb6CQyniQeOtrI4AAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Poland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAMESURBVDjLpZNrSNNRGMb/ViR9qw9FUSQFQX0IMshI9EMXJIIuZGFZGWZpqSHmxM25dNq8pk7LzTSdc1u6malo3vI6bHmZrmmp0+mclrfNuTmvk3r6zw8rKfzSgQfec16e33vew3kJAMT/aN2msTDxjKzoaX1nOXXmczXd0lkRbmkRB0/W5ASXlr4KP7UhQCqJ5XTXUlfGVK2YnhiCyWSA0ajHt5FudLcUovq137w4NZDxT0BTIStNLefCoNNCpTXgbYMGnOKvSJd8gaBKja6BSWhUMlRmPwSPdT90HaBGEO8iL6dY9FMaSBXjeNeogXrMBL3JDJ1pHqpREwS1apQ0D6NfUQVhzI2F7Fh/Rxugjh9WOUgm+kZmIKkfhnUZjEYMfJ/AEhlbZf4JZFao0aLU4oMwBJkRNwU2QEP+44lxbQ+ENYPoJSsvrP6EeWEBGbk8TJGgueVlFNc0QDpgRFKBEj3tYmTT3TU2QD0/cMmg/4ZEkRJTixYYln9ghczQopgQvitDWCQTtbI2hIjd8IDniFFNG3Lp1xZtgOosvyX99BCYPAVGzRYS8gNjxjk8e568ZpYquqFbBQJEp8Es94RH5mHk0Nx/A4pTvIaHeqrAlijRPGjEONn02JwFQSJXBAmd8SjfCT65xxFRch2SjjRQii7DLXU3XJN22K0B8lhevCYxFTLlAOIlKujIBzNYyIqCkyjt4qC48+WasbCDDXYdBfxPiXgocsOJOPvVozF2dkROXMCx/GiPxX55PkRVnUiQ9EOhmYUP2a/VnFIbhITqALAqfRFV7o3o937IlMbgdp4LDkUSK2t9ZDG9qW/ir6O3lYPGdjliea24lX0E4nY2RK3J4MsSkfsxnoT4gyuNhq/oPA4wiL69NGKb7UdlRNxhZFGvmMu4nuiqZ+Eq9yAupO/DudRdcEnaDi+eMzjNUbgncIMDg1DuoRH2fw1TBsPbKS3UveDFk0taLuXiolXWmE25Kj4as2n2Lv8sHOiEnDRv/ec0biTyyrr99M3YSSO2/Hn+CweZ2kRiltpxAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Cuba",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJ0SURBVDjLlZPdT9JRGMe5qFu2Lrt1a63LWv9ATRdN5xvLsnLRipzZpIVpigjyIs3XAOUHgopoWkggP5QXSRJwJQmtm/IlAWtt3XXTfubS+nZ+P1eby6ldPGdn5+zzfb7Pc57DA8DbL9rjrYxuVsXf7W5fuC2mYawpE7QRJZpDDfz/EngYVTN9qR4EPvlgXjCiKVCPWvou/0ACxDJjSbIwDefqMPxrEzC87IDUW4Pq8Vv8PQVaX7Qw5qQRgY9ePP0wDMeSFfWTUkxmPeiI61DlFOP6SAV/VwFtRMFQCwb4CdwW10IbVcK+aMHgohmPlwdBZ11oCctx1X5p/R8B9Uzzuum1ntj1Iv1tGRtb3zH2dgSa2eZtOOOCMizD5cGyzR0lGBNdx1TP5T96E4+4WttiWg6mYr3Ifk1DF1PBmxmHYlrGZkbFUDku2oSHOAFjolOuIpZ65rs5+MmKg9hWcJlZWB1UbsOhRjYz5r/MoSn4AKWWQg0nwFoyzndhijRobGWIq3XgPQU1sa2LqjCRHoc81IBK9w0OnvscRWQtBGFfEc4b8o7wNDMKOwnY3lDwZZ+h1idB/zsThpf6CezkstVN3yNwHFMrNGqCVRvlA2UQ6POkud1nTvE0EcVR1gU7JNSCnrPrWLRtw+RM7BKBXnJDP9eOYqogVNAj0Av0uTk7mtjov2+1p2yQ0hIYXnXCs+qEzF+HC9YSyIiIsK84XWTKP5tvPHdi11GupSXHW8JNW+FMAHdclSCCKDEX/iKdDgotRY17jTu31LhvHybT5RGPin5K3NWs1c0yW+lp0umc/T7b383NUdHJa44rSfJU+Qf54n/iNzi8zBtL0z1zAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIgSURBVDjLdVI9a1RBFD3z9r3sVwrdWCwYUkSLWKaQWOwf0EpIKSIi6QSxWyxSrE3+gUVEQREsU1ooiIRImhSCCImNIcj6kcVNNm/fzP2yeJu46yYXDpdh7jlzOHOdmeG47r+7azeuXMdWZwNiClEZQMHKuHqhgedrL/Dm4Xt3zIkxVEwMtXxYVMCqg/4PIfAw5T+BwDADSGRIJIeq5neeRgSi4QMFRhEVFKMSSBhBCEEIJIxioYyyTYICne2AArc62x+X72Q/MXXQRplzu2kUoV2ZwttvH0CBW2cKvLJfe/3v+7147vYkTc/gSCIYZ3CcYrq/i1s7r3tLs25vmOOOf8FeXlsA3FqYf1T3oQhN/4CzIxhlMA6AK6BYcqhsP2mD7Gby4PPmaAbCTZ67V/dchqRdSMiJRgGapeDub6SdLrKZxboeSnMsRFNuUHUW2j/MiRwAJih5GAco9cEH++hzBfDSGM9AraZWgFEG5QATgnJOljAQ8RnEM1Rc7ZRvNJgIlOnE+glk0DnAxMP0lD0wtY6jHqAyap19ngN5AAqwBwidcQdC63H3C1ycQCWMWM9fFkRJGSX/AxywPu6gryvx1rN24lJESQlQhQnBiAAzFMpVFKsJ4k8bbdNoZWwPACA8vrwERivML9aziYsQVphPAUoxcbSLeGujreyWz63urJ4qAABZ89KC9rgJ0oaaq0EAM9dRxrpOJCvnn37dHJ7/C8hDreOQ71qxAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Portugal",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJ+SURBVBgZBcExbFRlAADg7//fu7teC3elQEoMgeDkYDQ6oMQQTYyGxMHZuDA6Ypw0cWI20cHJUdl0cJLIiomR6OACGhUCpqGWtlzbu/b97/3v9/tCKQVc/e7RRXz+7OrSpUXbW7S9tu8ddv0M+3iCjF1s42v8WAP0XffKi2eOXfro9dMAYJ766SL1092jfDa17DfZgycHfvh7/hau1QB9161PhgE8epoNQlAHqprRIDo3iqoYDSpeOjv2zHRl7atfNj6LALltJys1Xc9+CmYtTxtmR8yO2D7kv4MMPr7x0KULK54/NThdA+S2XTs+jOYN86MsxqBGVRErKkEV6BHynp//2fXbw9lGDZBTWp+OK7PDzqIpYiyqSMxBFakUVYVS2dxrfHHrrz1crQG6lM6vTwZmR0UHhSoHsSBTKeoS9YU8yLrUXfj+w9d2IkBOzfkz05F5KkKkCkFERACEQil0TSOnJkMNV67fHNdVHI4GUcpZVFAUZAEExEibs4P5osMeROiadHoUiIEeCgFREAoRBOMB2weNrkmbNz+9UiBCTs1yrVdHqhgIkRL0EOj7QGG5jrZ2D+XUbADEy9dunOpSun7xuXMe7xUPNrOd/WyeyKUIoRgOGS8xWWZ7b6FLaROgzim9iXd+vXvf7mHtoCnaXDRtkLpel3t9KdamUx+8fcbj7YWc0hZAndv25XffeGH8yfuvAoBcaHOROhS+vLlhecD+wUJu222AOrft/cdPZr65ddfqsbHVyZLVlZHpysjx5aHRMBrV0XuX141qtnb25bb9F6Duu+7b23funb195955nMRJnMAJTJeGg8HS0sBkZWx1suz3Px79iZ8A/gd7ijssEaZF9QAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "U.S. Virgin Islands",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKZSURBVDjLpZM7TFNhFMd/t/f2IqVQqAWM72IVMUEjIRoiYnTxEWEyTjqoiYNuxkSjk5uJg4ODDjoYE6ODm4sOJlopqNRY5VXC09oCRaCg3t572++7DspTnTzJyTnfyTn/739O8lccx+F/TBsdHb0MHAOQUuI4DlLKJS6E+CP+9gdKKpXKBwIBFWAxm7n8b3Euj8ViQnMcR3W73dyMCmzjG9PxVzi5H7jKa6gI1nLE208oFOLy8wyGaWNkbQwzx+PTIYQQqrb417reW+RT7xhJJBieMHCufgQgl8txbV8hUhbMrwUghECbewDkKnfStH0NB3SN1o5OYqo63xgOhymWXQQyHajeWka+vsRdth9NCPFrOC95m16Npk3jLSkhau9masoE7y+A+tA0+cQEhetO4AvuJDNUTc+LhwsMMok+yoNVPNHqmPpss8Kvs+pHEgAr/QzViuPfvIepgR50xaa4ZBXe0soFBmuKZumaLEX6Symr1DFnTYrlBGq2G83di6/qINboI3SPwsiHXqSjk/Q1LgCcP9wwfwvDMLAsC2syQYHZiW9TC2byDi49j9u7gSLnC4FDNxho78Y1B5BIJIhGowwPD+PxeLDGwpBpxRdqwUzexuXOYc9uZOzle2aqTlFYvgkpJUosFusWQtQIIaivr1cikYhjj7dR4Rlna1Mz9vh9FNXGnFlLOvweacwE+7ZcGfp9ux5luRbunVt/pqH55N28UsFKfytlFTrmzDomX79JSyvbUH2hbXCJFpaLo2TjlrvbGs8Sf3SRvnCEgvU7yKfjqTJdPVh7qX1web9reSHeP5a3u54S3LGXoqJqkh2fvptZ+0jtpfbOv6nxjxWON/mzdVWV2q6aII7bimTTE6eOXv84+C85/wR0RnLQ/rM7uwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Iran",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAADpSURBVCjPY/jPgB8y0EmBHXdWaeu7ef9rHuaY50jU3J33v/VdVqkdN1SBEZtP18T/L/7f/X/wf+O96kM3f9z9f+T/xP8+XUZsYAWGfsUfrr6L2Ob9J/X/pP+V/1P/e/+J2LbiYfEHQz+ICV1N3yen+3PZf977/9z/Q//X/rf/7M81Ob3pu1EXWIFuZvr7aSVBOx1/uf0PBEK3/46/gnZOK0l/r5sJVqCp6Xu99/2qt+v+T/9f+L8CSK77v+pt73vf65qaYAVqzPYGXvdTvmR/z/4ZHhfunP0p+3vKF6/79gZqzPQLSYoUAABKPQ+kpVV/igAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAH6SURBVDjLjZPPaxNBHMVT/wgRsVDPgpdIya3QitWDepAqWKgHQaSiPfij4CHtRSEXRUmwKYW2emkRoYgHUbQEkVLFSmoJXWtRUtlkk7WZ/TW7yyY+57t0wyY1moHHLuz3fWbesC8CICLWAaGoUPd/1CW0hzyBIjuAqOM4zPO8WrVaxd8kviOZTD5ohgSAbjKbpgnLsurSNA2VSgWKoviQQqGAVCrVAKHVQQAasG0bruv6T5JhGGCMoVQq+QDOOWiTdDrtQ3YByByIAGTQdR3lcnlXpJ076WgAiBj1AXqn3EEUVVX9k8iy3BrQrDBE1xh+ZhLYenkZlbWn7QHCEOXDFNTlEXjGMoqLF3Hn7L6RtgCkX6tzKGWG4LEnYGvjUJfi2Hh82n5x9eD5tgDym1G42/Nw5Dic4iRYNg6eH4c00cNaAujogZSlhzA3E+A/hmHnr4N/vwD+dQCfxmLGPwGmnIX8+gqKmUvQpSHwjVOwNwdhrQ/g49hhd+ZcV+sIbP05thbETvk0rG9nwKVjWEn14Mu9fuTuH8fN3r2jzZf4uyH3q2GReRb6agw814/PE33IvZ2HazC4plYjT7gLR8TfZwljvUzFxWtwlbuwpJNYedQH6d2zAF4Ts5Q9GgZ0EiRc3blbh6azU0e33ydihRsn9t9uqjVVv5O8fwBNdbGhhwEriAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Guatemala",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIcSURBVDjLjZO/T1NhFIafc+/trdRaYk1KUEEWjXHRaCSik+E/cDHGzYXB2YHRhMRFY1SYmRgYHZ3VxIRFDYMraMC2hrbQXm7v9+M4UGobiOEk7/adN+9zvnNEVQEQkYvAGBDy/6oBm6rqAVBVeia30jRtGmOctVaPU5qmuri4+AaYAgJVHTKYNsa4drutnU6nr1arpY1GQ6vVqlprdXt7W5eWlvomMv/uw6tSofB4p+NOF0biYtc48tEAhXiuTZzh/s1xyuUyWZbhvWdlZeXt3Nzca14sf6zW6nXf7uzrcfq9s6sLy5+1Xq8fQQKmo1ZCvlAoyo+tXT5tPGO09IckM2zWznH3/AJ3rl5ACInjmGazifceay2VSgWASISSBaz3FIs1RnJlPF18vEG1keDVk1lLFEWICM45wvAfYqTKriqje0lGI01x2qFtuuwkKQ26oEKcCwnDEBFBRA6HfmBw8JWwl3o2ti7j8+u0TUKzcYkrY/n+wyAIEJEjSxEglLyH5r7j+tg8T1oVZr8GzE69JIoiFMiM7zeHYUgQBAMJVBGU77+eYoxhLcvIxnNk6w8xxvDo3hqH+yIieO+HEkQB/qe6bPL5g/cckCkDiBhjOJULhlCGDJIkXX2z+m3GeW4UCnExyxxxHIIOLNLk2WP5AaQXTYDb1tovgHCy8lEUzQS9g1LAO+f2AX+SZudcAjgZOOeJ3jkHJ0zggNpfYEZnU63wHeoAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Honduras",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAEwSURBVDjLpZMxSkNBFEXPD2IhVmKlS8gGXIBdsHQRkt5dWGYfFmYXtsHaQkTQRlDIzHv3WsyPIfiDSh4MU8zlzJ375nW22aX2fhPc3D1v3JA21xcn3Z8BAKdH+9hgm8fXMuzg9v7TBpRgwIbLs4MOQDYSWCarhgEpOD4cIcCCl/cmzDRKkEzKlNgCsCHddhlWugiRaVIiE+oyhwGRNJs9IHtdTTeITOZPByOA6XRq9Q5C6zWZTFyLqSFqiAhRqhiPx94AzGazbuWgLaMU8/m8KyWJFFlFDVOLWCwWP9sYakHKbhn0Tyghovr7CXVbiJki1a0z6E3WZbMvNU0t3hKi4ektyb4jqx9eQkQay62V3gK4Oj/shn5hrUmGkVcQ/W8WIszD4weyBs+7XadxxI71BUieEw+8ru7iAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAGeSURBVDjLxdO9SwJhHAdwIdpqrKmxNZqKuEUhSIyixCI0yjPv1PM1z8KDEonrOPF8OzcVhYoCh2gXp/wzcnmGgiDX1m+PQsZR9EJEw5fnWX6f5/e8mQCYfhPTnwHZbMapKPL9jwFNy47QYllVlWdZPsGXQKGQZwqF3CC5nMbQ4rt6vYabm2uk08fvAOLfHzcA+byGclmHrhdRKhVxcXGGZrOJ8/MzSMlDA0B8MZ7sBqYMgKZl0Oncot1uo9VqodFoQJZlCuoQ49EhQLgo98SHQDZYiaw4J4YA3Suuri6hqioURUEqlYIoinR+ikhEGACP664ucfGLj04PyPKWoStT/6BqtQp4nofb7YbD4YDNZoMg+Gl8r0CP2HcW6QhiWTMCR0cSqtUKJCmJWCwKu30dZrOZYjvw+71vW7BuCr3VTZB5q0hmLWND4OAgjkQiRotDg5bDYWGAeDxu2pXHeIhzS0EyY540dBDfDzOhYIAJBDjG59tjeJ7t9qFkUgTHse+vcXph9NOHRFcd4bysQvP8EfDtp0yhbZqH//tM380L5ZG0STFOrDMAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Morocco",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJGSURBVDjLpZNLbMxxEMc//+42Sh/b7cOjEVXV165UDw7iSkIEFxcuEpc2JOJxQkIkHnFz4+Ikri6kRBsbKhLR6ksvJEokdotVVbZLdx4OW0pajcRcJvkl8/3N9zMzgbvzPxGe7/Hs4IkRM42rmqvq7fMbL+34m0DB3OLjFRjxppImGsoaAlHduFAHcwROtV0cn5bpTM5zZKYziMjwQgKBu3Nu6KSbKaqG5rO3RJsDMWEoNfxZRFVVC0SEq7uuR+cwUFMaixswN8wdxwI1wx1i1bGIuuJuPBl9Oj9EVUXdMDeSX98w8W0CccHcKQhCmDn1kQZE5C8CooykRygrjLCsuIYPU2nUNW/Hv6OmCEplSSW7r+10EUFE6WzvCoLf9+BIosNj1TFGPg6iZpgr4oa6UlYYYWXpKswcx0j0PeDugUTwxx6IKOqKaD7rTLGa0vjsJWsH7hBKjZGNljJZE521cPheu4so5UXlqBk5z+WZmCJmtD1LsSldQPPeoyyqi5Md7mLpw266txQeCv/8Ob6sBcV5NTlKrKL110TMjfreBE37T1P08j70nGNJpJw1tbX0P/ejYYCcCIIy+L6fdVXrGR17RTKdQlWpilSx4VOGouV1sP3YLP0zKwhZsDrfQU5QM+KVrYgayXSKG/tuBQDbrmz2bHkJU4OdFN88yPfsGFPAl8kQGiI5Y0HofdGHqDIzom+zYMUGVtcEVY97gtqKxYRDhXz5ILx+F6jjl4N/PedHe1Ydz4wnO0Ia1GrI3zpc2dolF34Ah+h1f9LfEqAAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAADZSURBVBgZBcFBbo1hGAbQ83+5kRCJhA2IEQMrYAPMxRZMbcLG2ICRGTeUtE1jpr1p3/95nLMV8PnL3eOT07Pr79f+/f34GuAAcPfqgXseunlx6ysADsfC0+3k1n03ODP41oiX2+IReO7KH7sfLr1HPBEsCOKNc0cXPghGDFZUUPHWb+/UIKpYUUXU+LRFBbsYLCqICkbsiArWroKIQVQQFayIYFRQFYwKVtQgqhgxiNixooJdDKIgCtaIHVFB1KAqWFFBVDCiiAoOuzMwfgnqpyCOYCsAAADgP4mZnXDW2crZAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Poland",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAQAAAC1+jfqAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAE4SURBVCjPfZFNS4JBFIX9UfOfpl306XZ+QYhG9UJtiihq4cJNQdQsIulLKhs/CAlNy9JRX+slKel0nFdCjOJsLvc8c+6dmQgi/+unKIqCyuucNTarb9SVGAOKsmAaCNCn3lBHxlzIEYC23wPQQxc+3lkFOPXTcggw3AzsNlqwVBMNh2hzKByQV4NGClGneWoOK+yUkFIOyOmAsVFcurMveMYZZrlJC7vaAbe2jw6B0HxEDPeYYfWBLeuALIE2g8/ZrNKexhGBOjPWQ+Bad7lSEhNs7tGewiQWeZ8y1sIRGVXFF80nxtewSeAOFXziBF64ZFocmw63rlFVPGADRR6owDOeGD7Ugdz3m2y+uhyfp8vw/IQceeqk3DEZjgg4uwSNhInJsc/aFqtqWS/ZuI3pBRUXv37zL30Ddxx1NEzXzZIAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "United States",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAACxSURBVDjL7dI9C0FxGAXw8znu5/IdZDGYjI+BzWSwKFnlpW5dcaPkbgalPInyzqSrG65w0/EJlH9Ww1l/dU4HJPFL8Ac+AB4sepCoDw1dqG9DdlVYJoC8VsLI7/B5dBhMhNMy5Gvg0YNGJ5f3bYbhPMVw3+SwAP0aCBzo49jmbZnmVeO8rOvs5gyAQw3ij4XhweZ50+BiIKwkDSrMKrBGRYiXh7Yy0FICko2ZjPh/olHeFCjwX864N2kAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Netherlands",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIbSURBVDjLpZNfZNVhGMc/7/v7nTq1P9Vkso0kJy1ZjZWZ6CKTlMW6qYmUFNkuqpslYnSxXYwolXURXdRNTRszRU2aWTRbaTctUs1pSjSn/M7vvH+eLn6nsYixh8f7PK/3+fD9eh8lIiwnNMuMZQNCHtb/R4MH48EasB5MAaxL7hxQEIghBCDT9s+sX5zOg3NJbVyxtvDiQREAkMuC94grPrAWcRaMRaxJemMQa8EaUpVbIZK/AAERaLiESpUhU7cR59A7ToONcMPn0QeuoVJp7EgP8mUSjCkCrE20iYdUOTLehWq8gnIx/vUtcB69ux3Mb8xAB0HdUeyniQWAxpgE4AV0CKUbwVtkfhbd1ImuP4WfeYJav4XwyB3851fgE4nEQkiUT/R5jwLU9hPIhyEorcY9akPv70Vva2W4r5URX8J89AsTaZrjrxyLhZDYJjTvwRv8xHX0rgvI+yGC1nvgDIODXUxVrGNvbQM1FRlGph8z8O4l38sDlPRUCTuPI/xMXLcWMYnTYhL3z87lOXzwEASaltoOep+dIUDT3z+IJhIwBpVPo/Or0PFqAlNCYMsJZS2hVPAt94OUKqWltgOAi/v62FxZR0FBSCTw/P7Cz8IJFBafueo009kx3mRH6Wy+S/fTk6SDlawQUEvZxsb2qqs1m9ZcbqrbQ2ZDPTNzk4y9HWX243yvWuo6N7ZXdQPngDIgB9wcv5Ht/APUTCZid72ZzgAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Ukraine",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAG7SURBVDjLjZMxi1NREIXPC9HCKGGN2MgWdio2utZxA0KKVPkBwqaR/IS0dqYx/0LIVpsuBMFKA5LdQotF1kJWcMvYmBfemzPH4r4X3+pDMjDM3MvMx5m53Gg4HJ5L2pV0OhgMHmAL6/f779I03Sd5WgGw2+l0QPIetrQ4jvd7vR7iOL5fJXkymUweXb1+OzparCQATiCPDsAFkMDz5rUIANbr9dvRaPTMzN5HkgAAR4uVdmoVQKFJHhqlEC9+Og6eBkDRqnlCD8V5Q+4S4A6Yl4+zAeSFyiS7/wVhOWEzwuGHlW7eqEACPp0vgyoJJCA6zAE3hxlgJF4d3I0uKTABLIxwZ+dKUOECXXCGSApff6QlO2BBNpWdBXcHHSAdZAAkqZcABFwsHXQPxS44HSSyuz9K0lT/AopP9PJwKZpvJNMdbgp7oMOsBFA0M8EKkjc7yHIz/h+QJoRZddNoVLZMhxOXFXS73UWSJHskj6fT6RMASM1x9v0XUgdoDiNgRjjD03588wK3Xn+RmZ2h3W5rNpup2WxKErbxRqOh8XisWq2mqNVqHSdJ8pjkyXw+39vmN9br9c9m9pDkt98JJaJgEg+kbwAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Sri Lanka",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKUSURBVDjLhVNdSJNRGH6++enSTc3Rl9Y0KzRcoSHShURERRldlLGLMsqrCO2iLuwuL7qKLr0MoQvDHJigJkEbG5mGdzKU1PnvN7I2Fgu33Or7W+858YkrpRee8x7ec97n/TtHyGQyCAQCVtJXCS2GYdSQribQ1vhEeon0C0KgublZx18i+P3+43TJI0lSXVlZGWw2GwoKCsCINzY2kEwmEQ6HEYvFPpLtptvtXs9i8Pl872VZZuEyu4mqqplgMJh57O1Ya/e25jByExZaTpSWluJ/4nQ6kdZSTlXRAtvtIkXmTNPT07Db7RwlJSVYSS7infwGa8llaJoOTdXhLCwX7Zr97C3PdW9fy2BTFoHD4WB1IhKJIJH3HZPKBA4UOXHh4GXoGR0GQTd0vk+l0peuPW9aGm7zVolmLSyyKIoUTUMgPoN9uRIk635MRYNY+bYMVVFRXlTBz0PhBf/Ifd9FloHFzIAdULM4FhMh7jiyMIREfBOte9vwtLEL65+/anNyaFz5qTSdf3Y6P6sEXdc5CcO9Qw85UTQaRfJHktvYnTzFqpPzOV/HmEG+6awMzOgmyRahquHtlyF+p0FoTJCz/s8UGExHk1DRflHjDAxHBpBSNrldURQ0djaMUT/O0DgZuSyySPF4HPQS+QTS6fQfZksuBuQ+5BXlQFDzceflDWqkJh2tOCydqq/H7Pw8xsYnvILH47lC7P0ul8tWWVkJq9UKQRBw99VtFBcW4+Sx2q3xmeNcWl2F3z86qWv6I4Gl29vbe4RIOglui8VSzP4CK2dQfo09ksgf0kxoDhpPm/VG/0DOT1Z7wqOcYLt0d3cXknMVwaCmhjzRHi+l7pjqmq3b8Y1v/xg7ofZBTY6rvbp/t/PfI0AjgZ0qo+wAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Mexico",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKjSURBVDjLlZNbSJNhGMfnTZddJHS4iFJzdhFSRAc6WClJNmbMZrA+0x0+dQesXGpTnDo3aylmSToSgqiMqNTmFC1aOVMHuSG6DS22SK8aMQPZwanj375vMPuoC3vhz3P1/Pi9z/u8LACsqampc6MtJD6ocvBOtBcsFuvwBrObak632Wz+z9Yx2K0WDBelYW1tbUOhISqVapPRaBS+vV2K8a5SDBemIRQKMRIIBOD3++NZWlrC6upqDMA0GMEQwWY0+3w+tKvL0MLZCm3ONqiILHyZm8PKygrTYEhbirGHJRgSsLG8vEynpnselZUN0HN3QHM+EdpoLTu5GdcLL6wD4gYTMYPBS2yEw2E6qqfzqMo7gTtkBh5X5qI8exeq+ftBZiYjGAwwDQYbS/CpsxgD+ak0nUrVk++olpHwOYwIzprw09KBXy4TepoKooBg5J8G/Xmp9IAoAHWNtvudGDdIEXC+QGj2DTwmHWqUCiwuLvqjgIPrBvXFGH1Aop+3J95M1j8HJzcPdTo9tEoh2m4Kobh6A8VSOe62tiIhIeEI02BiBMbcFBpgNpuh092CRCIBn38Rhq5HGBh+Dy6XC5FIBJlcgaPHjhviBqZaEpZ2Cfo4KfQAv907A8szHdSNeiiV5cjn88Hj8VBQQKBILEW3oQme1tMRhoEtatCbk0wbeAfq8bKWi8tiBfR6PTQaDQiCQHNzMwiRFGpxNjwdXM+6QbUEH9tE6M2OAcIhP34sfIW6oQlyuYy+ikAgoGuJ4hoW3C5kpO88+5fB66wkRCIR+iWoQVKrS22jy+WC1+vFnye+BxUVFUndnH3ou3IIrzKT4Ha7MRddV6fTiZmZGUxPT8PhcNB1cnISdrsdVqs1BqBAVISpW07VHdiukbATyf/5zr8BNamLpjmUSloAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Czech Republic",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKoSURBVDjLpVM9TFNRFP7ubWvb1x+QQAtRIFaRmEakaYiGiJaAurioiYsxXXVxMHESB40TJI5OOihxq0sZTDBq6kANikAJNLSBAokQ29q/1x/69673PoSoMS6c5Oa8c979zv2+k3MIYwz7MYp9mvb3IBKJ9HB3T7BSFAXcW8Q3P/KvWOTHXC5XaBdDRDIajZ7jflyn03VYrVYQQnZ+cr9bTJjwyWQSxWJxg+dv9vX1fST81SEevLXZbKRWlLE++wlyfBO5+BZq5ZIK1BkkWGxtsNoPoePUaTCdHqurqxzGLpDl5eVZDu41m8148+QBVoLv/qv5aP8QBm/fR6lUEsznNF6vd2xtbU3vcDhw7IwHBTmrXqxXymC1GpdB0XnSDvfFw7C0n0XXwGUYG5pUOYlEQtJyBrnh4WFLuVwG7wEGvHeg0WjUIoVCAay+jVx4FJbWfjQVMjB1diEej6t3uIQkTafTU3a7HQaDQaUVi8WQSqWQzWZR4wwK3yZhanbD2uZCfuMDVhYDKrharQoWE9Tn8z3f1ScKCGr5fF59XU6uIL8+CUtzI+o5P2zOG6CJ99BpqcqCMxihCwsLOQEWIJE0mUzQ6/WglKC6NYmW7ivA9ldMv3wFc2MJJL2E2o95wS7l8XjyVJZlRXRTkiQIKep4Uop6JowDrAzLwSKUcgxgCur5zzjiuYvU/DhQyYyqd7mWkNPpvOX3+8O8H8hkMqCEoRD1obGjF0oxxLEluK91Q6ls8l5F0OI4D33osX5vEsnO6EmBQOCFVqu92lRbIhKR0XrcyF+d5lormHkd5kVOgGgaAOMlfHk2EmeKMkj+3sZgMNhO5x5u9Fx/Cg1d47OQ5ln2x/5pjN34vjiHyMQjH/nXOk+NuZOsrkhM4YsklmjvsD2PneWa+QnIJn6IP3aTNQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHcSURBVDjLhZPZihpBFIbrJeY2wbcQmjxdIGSSTC4zQxLyAK4o7igoKm7TPW49LoiYjqLG3DWpZmx7/tQpsR1xycW5qTr/9/+n+jTTdR3dbhftdhutVgvNZhOapkFVVTQajSsA7FKxTqcDx3GOajqdSki1Wr0IYeRMAsMwpPNkMnEhdCZSoFQqnYUwikzN5EYH9XpdNU0Ttm3LcwJWKhXk8/mTEEauu0YhfhKRDcuysDBt5H5tk4zHYxSLReRyuSMII+dd5M1mAxL//uvgw8Mz3t4DWWN7NxqNKAXS6fQBhIkZ+Wq1kk3r9Rpz4XytPeNLF/iqAx8f9pDhcEgpEI/HXQir1WpvxIx8uVzKps7Kls53AvCjB3x7PIQMBgNKgUgkIiGSUi6XFTEjXywWsunxj433qoM7fQ+51oDMzy2k1+tRCoRCoSt3lkKhoIgZ+Xw+P4J8F4DPTeDm3oK92aZIJpMIBAKvD15UzKdks1k+m81cyDsB+SRGuG2tYVpPL8Ued4SXlclklFQqxWkTCaILyG3bgWXvnf1+v8d9xFPLkUgklFgsxmkTd5+YxOL8QHwWQBWNRr3ipTktWL/fPym+CKAKh8PeYDDISezz+TwnV/l/v6tw9Qrxq3P3/wBazDrstPR7KQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAI7SURBVDjLpVPPaxNREP7e7uaHhmxD09AaDzYgGCIBoeBFpJCAKIoXT54Cgh6EXL0U/C/EmyD2ZHMTTBSN6akXoWiIJU1qTU3L4kZjk+xms5vNurN1Q1rtqQMf895jZr5vZneYZVk4iXE4oQnuoVqtvjdNM2UDw+EQhmGMoev6GIPBgHwxk8mkKY9RC3byotfrLUUiESfoqE226fF4UCqV0Gg00tlstugosBkfh0IhSJIEn883TppMpHOz2YQoiojFYkS6ZD8XWblcdtjD4TA6nc4hudQKJTLGwPO8wx4MBhEIBFAoFFCv19MCsZN06pWC/H6/A5d9rMTGqL4MfrcJVbyMZHIBlUplSSAmRVEgy7IzIAoejUagYZJ372J7FfHzGqYS9yGtPUG/daCSCqSIiS6UZLfkSOY4bqzgLNvAQrKLqQvXoDTyOBWcx5y8isjQSHHESr0SqIAL940w65MRSt6Cqdbgn4lCOA1Er17E7cQ+BCrgJpHUeDzueFc+vVu9rzDa38DxLTBOgVdsAZoKVRocFKAv4AT+HZjbN7MTxfZreObsgsMKuNFv+98NwjJ0VFe2kduahqBpWiGfz1+f+MscH+W3kBC/48zNO7D0t2BmF59fdWF2ZPD2jHK1GexhusCOW6ad3I312St3L+mtpxCEKWwUe+rHNSl7Tuuv+AM8Fp/vdA/twj9bxkNn/C54XwRf3vzsfVr/8fDBcv3Fsct01Pa2W+86+x/m1V9Kf3NTfnTvWe3l/+L+ANeBhMdSVgxaAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Costa Rica",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHtSURBVDjLjZNLS9xQFMe138C9A/0OynyBUjeFQjduROi2MMtCEalS0ToLEdQMdEShoKDWRymKigWxII7PhaB9aBFUJjHJpHlnnvbfe27NJcVIDfwIyT3nd885cOoA1BHsaWQ0MZL/4SHjgciLCJpKpZJVrVava7Ua4mDnkCRpKCqJCpKU7HkefN8X2LYN0zShqiqXKIqCTCYjJGFyPQkooFgsolwu8zfhui4sy4KmaVwQBAHokmw2+1cSClpSUmr12MP7LQunii8klOA4DnRdv9USn0koePRiJDW+aTGBjcOLgAewlnjfYSuFQoFXIsvybQF9jG2avIKFPQtzOyZmcyZMtywkVAnNwzCMeMG7jV+YyFmQ1g30L2kYWitAWtZFJdQOzYREsYLhzwZGGF+OHez/9PD2k4aeeYUHVyoVPheSELGCwRUdA+zG/VMPeycu3iyo6J5WxDxIQFA1QtCauUwPrOpIPh/vSC+qSC/qPHn3u4uu2Su8nsrzZKqAoOR/BO2j+Q+DTPC0/2CdSu79qOLVlIyXk3l0zsjomJYxv6ELQYgQPOk7a2jpOnmcaG57tvuD3fzNxc5XB9sEm0XuyMb5VcCriBI7A/bz9117EMO1ENxImtmAfDq4TzKLdfn2RgQJktxjnUNo9RN/AFmTwlP7TY1uAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Japan",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKZSURBVDjLpVPdS5NRGP+97tVpw9nm5tpShiSsFhMMImiCQlAOk+im7Ma6UKK86g+oCMKwgi66CLuQ7rqqBRVRQS2aFIFeCA7xQjC3qbkcus/345zTc5aNoqALX3h4znPO+X085z1HEUJgJ18Ndvip84+uJBljezlnYMykMGCaMvRqNgw51t+cvBk78ReBBLeEIxCCQTAOwU1IMkFkgsh4JZuYeT55/J8OpAonkLaZrmzkspZAmUldhtXuxUTjbTy48Z62kFOTvBrm5fjd/oeqtOgJDvy3VxZ7h2vnDoFxgeR63nL/yfQtmv5JcPXlIubTOTCdw9RJgcLUWLXe77OBFKGbAgf9DnS1O3Dv8WdnpQXD0HDRHUexZmnbskEW9ap9We9q9mMkeRj2BgVLq1kEWh0wdANVAk6nzPTSNtCoAmUW2+chAYbJkUjmUSJXVQJdL1eAdY2eyomXS2UklvJIFRvhavFiNb2II5YSFL2A2LNJeFua8WVmA62qhp6eHps6Gf8G8XGC/gQHFxyszoFj/WcwdOEsCoUCksl9eP3qBbpqp3FqYBgN9fVYWVlBvXUab7/bryvyKgeDwcVwONxeLBbhdrvF+eFh5c7YGLa2toTP51NCoVAFlMlkkE6nYbfbMTo6img0uvnrKg9NTU19mpub++p0Ok05MTs7+yGfz5cGBwfR3d2NSCSCvr4+5HI5JtfknqamJqsqB4lEIk7paGdn5yVSGKPx7kAgoGWz2drx8XHYbLaKimzJYrFwuSbrVCpVVn5/jdTKgY6Ojqe9vb172trauKqqzrW1NSwsLMBqtcLv98Pj8dC7MDeWl5drYrHY6h8ExGzxer0hUoxS724CWeSLpd5HpKDL5YpSrtU0jZHTdXJ0+gdZxaA90+h/PAAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Latvia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHtSURBVDjLjZNLS9xQFMe138C9A/0OynyBUjeFQjduROi2MMtCEalS0ToLEdQMdEShoKDWRymKigWxII7PhaB9aBFUJjHJpHlnnvbfe27NJcVIDfwIyT3nd885cOoA1BHsaWQ0MZL/4SHjgciLCJpKpZJVrVava7Ua4mDnkCRpKCqJCpKU7HkefN8X2LYN0zShqiqXKIqCTCYjJGFyPQkooFgsolwu8zfhui4sy4KmaVwQBAHokmw2+1cSClpSUmr12MP7LQunii8klOA4DnRdv9USn0koePRiJDW+aTGBjcOLgAewlnjfYSuFQoFXIsvybQF9jG2avIKFPQtzOyZmcyZMtywkVAnNwzCMeMG7jV+YyFmQ1g30L2kYWitAWtZFJdQOzYREsYLhzwZGGF+OHez/9PD2k4aeeYUHVyoVPheSELGCwRUdA+zG/VMPeycu3iyo6J5WxDxIQFA1QtCauUwPrOpIPh/vSC+qSC/qPHn3u4uu2Su8nsrzZKqAoOR/BO2j+Q+DTPC0/2CdSu79qOLVlIyXk3l0zsjomJYxv6ELQYgQPOk7a2jpOnmcaG57tvuD3fzNxc5XB9sEm0XuyMb5VcCriBI7A/bz9117EMO1ENxImtmAfDq4TzKLdfn2RgQJktxjnUNo9RN/AFmTwlP7TY1uAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Indonesia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALcSURBVBgZBcFNiFR1AADw338+dhl3ZmfdXbf1a4NCwUSQOiREBVJhpmRoByGQbp26FJ66d4gI6iIFJRYRdQjCSiglsDIxNEgsK61tcc3WrWbmzZs3b95Hv1/Ye+jx0zNzM7ur1SoACAAAggAIyPLC7b9vn6nNzM3sfvv1d4RKkBUjAARBqRRAPIoQlGVFWZRKuRePvrC7Vq1W5TJh9L7+F5esPR1bObpgotV09eq3fuq/aXmlo9WadGu1o1qr6/YTR/aW6rWqCkCns6qzbUw3isSnroiim6IoEoaXDAc9g7gnHUQGg0iW9IVQIKgFQLu9jnJkzfPTvHzR+MFZc+s3aIyuGWRbtKZaxqoVtfqYKE6EMERQAYJOpyOKev6by3XXZgYf/UZeKOOzRsNI3OsbDWPDpC8dxkIoQQ2g3Z6jHJlqT+o8d4+1x1ZlD683Pju0kK6qNzdbM15VH6vrxSm6BCoEkCRD/SjW6Xb0JnL/biU5cV2ZJyrpZ07+uN+X1/fpR/8o0r4AgkoANBpTmpMz2u15reY69Wd2aizWNPI7bZi5YZinNs1uc/LaAdvn31KtFAJqAdDr9EXREH3f3/jLqSsXlI+k0u9+kWaZDdNbbZu/Xy/pe+mr97z21H4BNSEImJya182Gfohjf6R1WZF6dPsReVnIi1yhtNxZsmPTA6J04NkP9tgRnlaDsiydX/rdpRs/azZbkiSRZKm8LCyu/mpUZLJiZJSPdIc9Ozc/KBrFzg7eVQuIs76VfGR8rGmi0ZYMU0mWyPLMHZMLsiKXl4WbnT9NN+ddXPrG5eUr7u0eUCMIoaJl0iDExvOGNaEpzhLHz70iLVJJlrp7drtddz3mwuLXzi+e8+rBEz4+9qlaluXyPLdxeqeNMwQQ7NryJAghgMPH7hMqDZeXL3vj8Ic2Ti3I8k+EfYee+Hzd3Oyear2GIAACAOBM67i0LD3UP2RCS5blVm6tnPofTwlmPORvTlwAAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Sweden",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAMNSURBVDjLdZNLaFx1GMV/d+bO3DtJxkwSSWNq05YkrTVa04qIiOiiRIxgE2ohhUIKRQQFBcGiIiJiFaGIYEFERFy5dCE1pQ8JIbSEJhG66GM6idOk6Uwyec7zztz7/z4XlSw0nvXhx4FzjqWqbKXb517rQeRzFY2ryPv7Bkf+3Mpn/RuQHDncqqLvqMjbLZ2DCVNZZjV9uaii36uRr58Yunx/S8Cd8wMRVT2hIqfi2/u6tu17nZAYiplJIk6YpdQo6/em7qrIGRX5sXd4vLIJSJ4f6EP0Y6ep94Vtjx3BbeoGrRGs3eGv0dPsePx5QnU7qZZyLKamKORuTqgxpw++MfGbdXvk8E+IDD/cNWS5zU/iFZbZyN3E1Ir4pQyOVaWtYy94a4QbOgi5cfKZJIupKcprd3+x1cjxPYfOWn5hmWJmFKnlcco5yvkM+fkFDg59SyRWD6U0Wkph5ZO0tO+nsRmmf589aqtISbEao65DvLmDSu4GdU0JEk0xYpTBmwMTBW8BKvOUsxMU01dwdx1BjZRsFQEBrCiRxm4iThxvaRIpLhEJg1WegZBSy16ikF8niCUg6qB+gIpgqxEe9GBAq2DX47YeIIjGcL0VJHuRDb9A4DZgnDhSrkGgSC1AjcFWYx4UqgbEBymDVrEbthNv28PG6iR+yGVlIsfKtTm8xXVCD0VpfY5/EojEQpEIEINgBaQK4oGpgttOoLA6sUIt6/L08Q9xdvdQuX6BG+OX8IP1+pAaGZsd+4bK2hw47RCuA1MD9QFBfSFzJUn3S0dxZ0axfj5G3eyv7Opopja3HthizKuF+fHhW+mxU82dh7oe3d9POL4XyinwSpiqj1mr4bbthv73Nidsf/oIIU+czSlP//Bsq4q8q0bean9qINHe2w++R37+KtOffckzrwxSP3eOaiVLGSjkw9yaYeE/Z7p29kCPGvlIRY51vnjSqiylmb/4B3be0x0tgWWH7lHIBaQXw8b39BPr/+589UxPn4p8gEhURb7ierWntHr/zbCxdpqwLih89/KF4Iu/AXSvuZLBEiNYAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Malaysia",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAMSSURBVDjLfZNJaFwFHIe/N+ubdCb7UpK0FbOQRdvUi4cag1iC9NA2tGoKQgTxoIKeDFLqQTAHofZiL1aK4MVTT9WmoMGIJRLN0qpJmmQas00nmcky+7yZee//92QPEvzOH9/p9zNUlYNY/P5sNyKfqmhIRT7sHBidPcgz/htYGj1Xr6Lvq8h7NS0DlU5+h73VsYyKfqmOXHtmcOzxgYHlu+e9qvqmigyHmvpbGzov4hKHTHQKr99NLDxOYnN6TUWuqsjNnqF7+SeBpbvn+xG94q/q6W3ouIBZ1QZaxN5f5u/xEY50ncJVdoxCNs52eJp0fGFSHWfkubcnbxuLo+e+RmSotnXQMKufxUrvkIwv4BQzlLJRTFeRhiPtYO3jDh7FZYZIRZfYDk+T21/71qOOvNF++rpRSu+QiY4jxRT+XJxcKkpqI0Lr4Bd4A4cgu4pmwxipJWoaj1NRDTN3Vl71qEhWMSp8pp9Q9VHy8XnKqiqprAoQIAfWOjg+sCKQ3yC3NUlmdQLzqQuoI1mPipglKeDHi7eiDa8/hBWbQjIxvG4wco/ApRS3fiSdSmAHKlE3IKAiZR51xB1OjuKRPdqCr+DyHMKsP4ntC2Bau8jWDyRLaWwziOMPIbkSe1aOiFqo43hd6jh2ua+e5eTPjEU/IZK9B1rAE2widLidnBeKfhO7YJPOWfxSiPGdJ8G+4aCOqEdFXM3lfTT4Ovhpc5jfEreo8zZwIvAiQbMRW6Fg2cykk/zpZHAMeKn8ZbqSwkORovudgWN9md3Np4OhZjoOX6LOXctcepxH1hy27rOyvc2dxDZrYtEZ7OK12rOUJ4X1uVnsQnzCuP9Nr09FhtSR4eqW063Nx8/g8nj4I36Dh5kZ/lrcp85Xw+tNF3HnCkTmH5Devb+mop8jcvPJlGe+er5eRT5QR95tPHG+srHnDKVigtjGFEHHRXR+jt31iYyK3FCRa70fr0QOPNPv1092qyOXVeRSS99bRj62yuOFB9j5zVsqOvLClfDs/77xX3692t2vIh8h4lORz05dXr59kPcPXS/CRago2Z8AAAAASUVORK5CYII="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Brazil",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALqSURBVBgZpcFLaFxlGIDh9z/nTDJJJsmkM5OkOMlkSklT6w3FSxW0XooibioUKuK6qKBYXbgsqMULdFnRrWBd6KLSIBYjtcZaDW1C0zSxbdoG2lyaS0OSzplzzv9/nxNQEd0IPo9RVf6P4Pn3+rPFfOaHlsa6ImpABaeKSxKiKCFJEuJqRBRF2DDCVUPisMry/M3pqfHLTwWl9ubR7du6iuWODawTVdY5UUQUp4pzghPFOYcTJXGOMyPnNxyPVsaD23JNxUKjz4WpWaxznB69ykP39TE0fIF77ujGJsLwuats3drD4OAoXT3tOCf0FlspdG5sC4wBUSXlG5bWhIo1VFyKpUrC96cu4pwg6hHTQGTqWFxYoVRsw4pgjMHs/+ykejbEE8V4Ptvv3cLNuA4nghNFBKwTrAgtQYWBgSGitUVsnDB/fYXgl7Gpl/oK+n6utckvFIodfl2Dmb44zvTsIrF1WOtwTkgc7Hz8ATbfvkkmx1ZHZ1ZX5NL4rweNqrLu1YNHP3/wrvILfZtKtGYa2dLu8XefHD1LurGB+YU5Tg+N9h/+6OXnqPGo2f3Oke5cNrOro5AjdpCp51/y2WYmphZpy+ZIZfIP8wdvx5tfmHBp+cu+ckcaE4DxaEkb/qlj/Cse/eZFej64m93Dr7V9+MSd31JjVJW3Pj3hnry/15tbVcqdzTyyOUPg8ZdrRw6xdPIwvY/tor68jfDsMcZ+/E6XJ86/HlBTjcWbWVhmcuYW1SjPwKkxwmqMdUKUOHYOHOCZvftITx6HE+/S2JqlXCqZM7/pGwE1NklInBBby8TlazhRrBXEKdYKLWs3SHeW4dl9/CnYvxFfTE9ATTWOCcOYrnw9zgaIKuIEay2qKcLmHJWRfpq+foUonKUCrK74OJ/pgJorI+cmKjfm+1LpJsRZRARJHGpjxCqp7A7yPw9SyjUQ+ClW5y1X5jxV5JBRVf6Ln/Z0v31raXqv70zJ+Xpd4eOnj9kDvwPD/42l5s+BKQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Portugal",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALDSURBVBgZBcFNiFVVAADg75x777z50RmdDJG0phpTIwq1cqP9IBqlLaxNpYVSVIvahLVLCqFFoGEZQkQhgdGilUghaqRNIKgUZEmQlCBlmmOm772Zd+85fV/IOVuz7ejmgeHWxhgsRz8CCMiBnNQp/Xbln3w4XJ18/die9dMAIefssXcmjn326vIlMYZZmUIGIGfILl7r2Xfiir/OTbV//unM6Hd71k9BCbEIi/rKYtbpvxUxBAI50eSkrrNOr/HQwplW3FE6ni4O5rR48sFXDsz+dve6qQghhBk556KviKpIGSgiRSAEooBk3nCf9ffNMzbeGiiHhz6F8NSO1WdTHh2bNZhCk4Nl44+7fP2Sb37cK6NVzdCk2rplz9j0wEtaVandnbbpvZP1wbdXVSVOvfzI5ls7rT/9fvmMUyf3q1PbsoX3mG5q7XZHMmp8wdOOn6ulNG3VbS2hjDVEbPzw64PNDXnc8NCwRXfNU8ZBl65e1m53lcVcW9a8b3hoRH9fob+vkkVCBPHz1w5NtZsne19M7LVkYLWZ/QPGF92i2+mq69ILa3caqFqqMuorCq0ySsgZiNBuHy6+//WIXQe2u3/OBk3ZceeSu031Jp3+45CyoCqCMgZlETWJJgHx3jduevFa5+NqxeKVchXs3P+WRxc8a9Il88du99WJDzy/a0zIQRmDIgb9VdDUGURsI5s4fcQvZ3/QmW58cuQjT4w9Z2TmbKM3L7D01pUyUiajKqJ6ugbliXfPz3/4zYnOvq3L+y9eq8C/1y/4cmK7691JIUQjgzeqIlUMIOWsN5VACXXdaBoARobm2rJ2NwAAgJyyXrcGEeqplOqUMgAAAABAWcZUN6mGEnrd5sJQXzFH6A3lnKNMAowMlCBnBqooBKkqwn9Nnc5DCSHkHWu3Ht0QQlia5UEAmYwsAxl0U0qnymgf/A8eWStYAg6kAQAAAABJRU5ErkJggg=="
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Mexico",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHqSURBVDjL3ZHbThpRFIZ5i3kcLRYPqIgUGcDhNKBAqyKCobTR2NhiKmCstcWmBmtLPaCO4CQ6SBWVKInx0N70KbjhCf7O3ia0ZS686F0vVrL3Xvv7VvIvFQBVuOITQxfe6tj5IEPu9xW/ZxGcu2aJnAksxW9eYP42hmB5oBY48zAjJ240QoP7HH3j8xYhWgwiUgiAyxpFlTxZmL2ewvrPNBJX0wid+TF0zCsEHtEKGcbT4igWK0k8OwzBumGo0uZoeUCYuZzE0vUcVn6k8OSbUyFwyfDbSgKvShOIFsZgWTfU2K96pv5huOSm8KfvS/AXHAqBQ2CxcJFAsjwDe5YFgWkGdzCPoSMXHhed8BXs8B7YFALbVh/6Nx+RyWAzevR91qEu+Jf6XwRuecdkTSRp27YcVtaoCLE33Qn9sha6D+3oSrVB+07zO0RXzsx4chxmT18ifhqjSTcKej5qMbkfRVQM12EqILA8uRaRgnguhRE7mqJrahR0y5MjYgi+TTfsq1a0vVELVODYMVUJ/Lo0jZG8768d/1md71uhS2nBZxwYzwXRn2bxMNksqLgtoxgQ/RjOe2HK9FCrYaVLIehY1KB9oYVpnVfXnKscrMsmqBNNEm2a13ol05c7+L7SzD1gWpLNVXW8SST3X7gvtJUuvnAlAAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAALCSURBVDjLlZJ7SJNRGMaF/i3on/6wUDfbvsLpUiO1tItamRUISdmFYEYaGQaikNlIvIdOp9JSI0ssXOrmdH5ONzek29AmanPenU2H5rYyNZqa5dP3CY1EQzrwcHjhPL/3Oee8TgCc/kfDjQTZJ2Uvt4vcZXS9uUFO7BiUEx6UcfugnJ1hIn1hazqO5gzm8qYAYzNRRhknBmTEHNX114TiALRC5oo23xNSPqPxnwDKyB5REAuW7ngsWtVYsigx25kAa2MwDKXekKcyUv+c3cgcaWo7CFt/Ln5YFZjruoCZNyGwyDiYrvfHdEsoFOmMwXUAyuhMqXVKdxHfTNVYNFdiTncaX98G47PmEGwt+2ElubCqw9FZwFp2AEZIgk0Zp6i7rth672N5VofvxkzYtGGwaI5gsskfo1VeMEs8YamnUihPoS3LfckBGJCy1Tb9eSxNl8M+ngz7YDQWes/B+ioYIzU+6H/GwYcSAibxntVrTClOoj6FMeEA6CtYk/PGm5g3puP9C0/01Higr9oPo5QsLX7QFbHQVbgb5ioWbKoTGJcEoTrJTeIAdDx0fzxMBmFmiA9DXQTItABoio9BncfERwkXM0pv6IuZeFkWiKRHUYgtiMDlzKP28GQu3/GIrwuY2m6xL5UiBbI7XNhNAnzpSUZLric68l1RWxmEtNpokAYReqZUELbGIUroBf9bzgLHL6iymUPtFT5ofxqFMU0i7GPpGCYvoejqNvByQtHQW4iG/mLQS6COgVB9gwYsrJkBakDqNAX7oBIEQJbMgbYkBKIrW3H2ng8Uhif4e8n1IhqwfgqlKYww6V03aKmJM7efwad3YTh8exfyVNeQo+KtmnOUvI0T/C1xolu6OMEVmjwOsrIJRAr2Il91fbUzvdP1mjfYSM/jXbeUx7rwS6NdLLyYnfbAOOefdGxK85Qe0Gd+Azr0uSlwBNX8AAAAAElFTkSuQmCC"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Flag = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAHySURBVDjLpVNBaxpBGH2z7rrb6poNG0lSi0VyiA1I6a2XUtBLyD/oyV/gvSD03Gv/Q7El5NZDhBDx1lPpQUyRbg9SoUYTsEs21XVdM9/QWdZePGTgY2beft/33pudYcvlEvcZCu45VLno9Xrni8WizANBEGA+n0fh+34Us9mM5la1Wq1QHSMLvPhVMplsZ7NZkfT/iNvUNA3tdhv9fr9Sq9VaQgFnfGtZFobDIXRdj4rihbQeDAbIZDIoFApEWudwi3U6HcFu2zZc112RS1aokDGGRCIh2E3TRCqVQrPZhOM4FZXYSTp5pSTDMERI9rgSmsMwxHQ6RalUQrfbravE5HkexuOxOCCZRIdJs9xLjPaqqiKdTguV1KBM3WlDCdySkKwoyooC2Sifz4u8XC5HNWWFWMkrBX2QITGJP//2CdbVT1gTB896H6JfrFIDWUQMxWIxkkysEn/y6wJP/3yFzTYxe5TGFceiBvQHpL+4XHl45uf3SO15sPU9oMxg9D0cOCdCHWs0Gqfcy2HslkUzxaF9jH3NwcbONnR3Eziii8Mb/7jF98nDS7buMf1+wRraG7w2sQP92gJecnCDx5jf2Hc3H9c/Jh+j5Rnwd3fELYXA5T/8SwC4GK1X8Jg94E9uAhNJxVeC7ewWYHDkhrcOYd0B0mCFUhT4PX8AAAAASUVORK5CYII="
                }
            };
            var categories = new List<Category>()
            {
                new Category
                {
                    Name = "IT",
                     Description = "Everything connected to the field of informatics and IT",
                     Id = Guid.NewGuid(),

                },
                new Category
                {
                     Name = "Maths",
                     Description = "Everything connected to the field of Maths from calculus to applied matheatics",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Phyisics",
                     Description = "Everything connected to the field of Phyisics from quantum mechanics to experimental phyisics",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Chemistry",
                     Description = "Everything connected to the field of Chemistry from organic chemistry to inorganic chemistry",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Biology",
                     Description = "Everything connected to the field of Biology from molecular biology to zoology",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Economics",
                     Description = "Everything connected to the field of Economics from microeconomics to macroeconomics",
                     Id = Guid.NewGuid(),
                }
            };
            var subcategories = new List<Subcategory>()
            {
                new Subcategory
                {
                    CategoryId = categories[0].Id,
                    Id = Guid.NewGuid(),
                    Name = "Frontend development",
                    Description = "Educational projects related to frontend development"
                },
                new Subcategory
                {
                    CategoryId = categories[0].Id,
                    Id = Guid.NewGuid(),
                    Name = "Backend development",
                    Description = "Educational projects related to backend development"
                },
                //write a few more subcategories related to infromatics
                new Subcategory
                {
                    CategoryId = categories[1].Id,
                    Id = Guid.NewGuid(),
                    Name = "Calculus",
                    Description = "Educational projects related to calculus"
                },
                new Subcategory
                {
                    CategoryId = categories[1].Id,
                    Id = Guid.NewGuid(),
                    Name = "Applied mathematics",
                    Description = "Educational projects related to applied mathematics"
                },
                //write a few more subcategories related to maths
                new Subcategory
                {
                    CategoryId = categories[2].Id,
                    Id = Guid.NewGuid(),
                    Name = "Quantum mechanics",
                    Description = "Educational projects related to quantum mechanics"
                },
                new Subcategory
                {
                    CategoryId = categories[2].Id,
                    Id = Guid.NewGuid(),
                    Name = "Experimental physics",
                    Description = "Educational projects related to experimental physics"
                },
                //write a few more subcategories related to physics
                new Subcategory
                {
                    CategoryId = categories[3].Id,
                    Id = Guid.NewGuid(),
                    Name = "Organic chemistry",
                    Description = "Educational projects related to organic chemistry"
                },
                new Subcategory
                {
                    CategoryId = categories[3].Id,
                    Id = Guid.NewGuid(),
                    Name = "Inorganic chemistry",
                    Description = "Educational projects related to inorganic chemistry"
                },
                //write a few more subcategories related to chemistry
                new Subcategory
                {
                    CategoryId = categories[4].Id,
                    Id = Guid.NewGuid(),
                    Name = "Molecular biology",
                    Description = "Educational projects related to molecular biology"
                },
                new Subcategory
                {
                    CategoryId = categories[4].Id,
                    Id = Guid.NewGuid(),
                    Name = "Zoology",
                    Description = "Educational projects related to zoology"
                },
                //write a few more subcategories related to biology
                new Subcategory
                {
                    CategoryId = categories[5].Id,
                    Id = Guid.NewGuid(),
                    Name = "Microeconomics",
                    Description = "Educational projects related to microeconomics"
                },
                new Subcategory
                {
                    CategoryId = categories[5].Id,
                    Id = Guid.NewGuid(),
                    Name = "Macroeconomics",
                    Description = "Educational projects related to macroeconomics"
                },
                //write a few more subcategories related to economics
            };

            var investors = new List<Investor>()
            {
                new Investor
                {
                    Name = "FakeCompany",
                    Description = "Descriptiojn of a fake company",
                    Balance = 0,
                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" }
                    },
                    CountryId = countries[0].Id,
                    Email = "fakecompany@gmail.com",
                    
                    LocationName = "Split",
                    Id = Guid.NewGuid(),
                    NumberOfEmployees = 10,
                    Password = HashHelper.Hash("passWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XUkyGFGbqMDuzt1u3xhGAkTtS"
                
                },
                new Investor
                {
                    Name = "FakeAdmiinCompany",
                    Description = "Descriptiojn of a fake company",
                    Balance = 0,
                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" },
                        {"admin" , "true" }

                    },
                    CountryId = countries[0].Id,
                    Email = "fakecompany1@gmail.com",
                    
                    LocationName = "Zagreb",
                    Id = Guid.NewGuid(),
                    NumberOfEmployees = 10,
                    Password = HashHelper.Hash("PassWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XukyGFGbqMDuzt1u3xhGAkTtS"
                },
                new Investor
                {
                    Name = "Investor",
                    Description = "Descriptiojn of a fake investor",
                    Balance = 0,
                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" }
                    },
                    CountryId = countries[2].Id,
                    Email = "investor@gmail.com",
                    
                    LocationName = "London",
                    Id = Guid.NewGuid(),
                    NumberOfEmployees = 10,
                    Password = HashHelper.Hash("password"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XukygFGbqMDuzt1u3xhGAkTtS"
                }
            };
            var organisations = new List<Organisation>()
            {
                //implement a few more organisation

                new Organisation
                {
                    Name = "Fake event organisator",
                    Description = "Descriptiojn of a fake event organisator",
                    Balance = 0,
                    Type = Shared.Enums.UserType.Organisation,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" }
                    },
                    CountryId = countries[0].Id,
                    Email = "evets@gmail.com",
                    
                    LocationName = "Split",
                    Id = Guid.NewGuid(),
                    NumberOfMembers = 10,
                    Password = HashHelper.Hash("passWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK5oN6XUkyGFGbqMDuzt1u3xhGAkTtS"

                },
                new Organisation
                {
                    Name = "RandomCourseCompany",
                    Description = "Descriptiojn of a fake company",
                    Balance = 0,
                    Type = Shared.Enums.UserType.Organisation,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" },
                        {"admin" , "true" }

                    },
                    CountryId = countries[0].Id,
                    Email = "fakecourse@gmail.com",
                    
                    LocationName = "Hvar",
                    Id = Guid.NewGuid(),
                    NumberOfMembers = 10,
                    Password = HashHelper.Hash("PassWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XukyGFGbqMDuzt1u3xhGAkTtS"
                },
                new Organisation
                {
                    Name = "Organisation",
                    Description = "Descriptiojn of a fake organisation",
                    Balance = 0,
                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" },
                    },
                    CountryId = countries[2].Id,
                    Email = "organisation@gmail.com",
                    
                    LocationName = "London",
                    Id = Guid.NewGuid(),
                    NumberOfMembers = 10,
                    Password = HashHelper.Hash("password"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GsnK58N6XukygFGbqMDuzt1u3xhGAkTtS"
                }
            };
            var applications = new List<Application>()
            {
                new Application
                {
                    Id = Guid.NewGuid(),
                     Name = "LearnApp",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Features = new List<string>()
                     {
                         "Good learinng experience",
                         "Amazing customer support"
                     },
                     AppPurpose = "To teach people how to learn",
                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest learnign app to exist",
                     EstimatedNumberOfUsers = 1000000,
                     EstimatedRelease = DateTime.UtcNow.AddDays(365),
                     OrganisationId = organisations[1].Id,
                     Markets = new List<string>(){ "Android", "Ios"},
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Application,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
                new Application{
                Id = Guid.NewGuid(),
                     Name = "TeachApp",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Features = new List<string>()
                     {
                         "Good teaching experience",
                         "Amazing customer support"
                     },
                     AppPurpose = "To teach people how to teach",
                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest teaching app to exist",
                     EstimatedNumberOfUsers = 1000000,
                     EstimatedRelease = DateTime.UtcNow.AddDays(365),
                     OrganisationId = organisations[1].Id,
                     Markets = new List<string>(){ "Android", "Ios"},
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Application,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                }

            };
            var events = new List<Event>()
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                     Name = "LearnConference",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Location = "Zagreb",
                     Activities = new Dictionary<string, string>()
                     {
                         {"12am", "pizza" },
                         {"1pm", "Work" }
                     },
                     NotableAttendees = new List<string>()
                     {
                         "CEO"
                     },
                     NotableSpeakers = new List<string>()
                     {
                         "Lead dev"
                     },
                     Date = DateTime.UtcNow.AddDays(30),
                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest learning event to exist",
                     ExpectedAttendance = 1999,
                     Capacity = 3000,
                     OrganisationId = organisations[0].Id,
                     TicketPrice = 100,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Event,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
                new Event
                {
                    Id = Guid.NewGuid(),
                     Name = "designConference",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Location = "Split",
                     Activities = new Dictionary<string, string>()
                     {
                         {"12am", "pizza" },
                         {"1pm", "Work" }
                     },
                     NotableAttendees = new List<string>()
                     {
                         "CEO"
                     },
                     NotableSpeakers = new List<string>()
                     {
                         "Lead designer"
                     },
                     Date = DateTime.UtcNow.AddDays(30),
                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest design event to exist",
                     ExpectedAttendance = 1999,
                     Capacity = 3000,
                     OrganisationId = organisations[0].Id,
                     TicketPrice = 100,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Event,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
            };
            var courses = new List<Course>()
            {
                new Course
                {
                    Id = Guid.NewGuid(),
                     Name = "Webapi Course",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Curriculum = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "Webapi" }
                     },
                     ExpectedApplicants = 100000,
                     ExpectedGraduates = 100,
                     EndDate = DateTime.UtcNow.AddDays(182.5),
                     StartDate = DateTime.UtcNow.AddDays(82.5),

                    
                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
               new Course
                {
                    Id = Guid.NewGuid(),
                     Name = "React Course",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Curriculum = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "React" }
                     },
                     ExpectedApplicants = 100000,
                     ExpectedGraduates = 100,
                     EndDate = DateTime.UtcNow.AddDays(182.5),
                     StartDate = DateTime.UtcNow.AddDays(82.5),


                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
            };
            var onlineCourses = new List<OnlineCourse>()
            {
                new OnlineCourse
                {
                     Id = Guid.NewGuid(),
                     Name = "React online Course",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Lessons = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "React" }
                     },
                     AvarageDuration = 12,
                     LessonsDate = new List<DateTime>
                     {
                         DateTime.UtcNow.AddDays(2),
                         DateTime.UtcNow.AddDays(3),
                         DateTime.UtcNow.AddDays(4)
                     },
                     LinksToChannels = new Dictionary<string, string>()
                     {
                         {"youtube", "stuff" },
                         {"facebook", "morestruff" }
                     },
                     ExpectedAudience = 100,



                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest online course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
                new OnlineCourse
                {
                     Id = Guid.NewGuid(),
                     Name = "Webapi online Course",
                     Goal = 10000,
                     CurrentAmount = 0,
                     Lessons = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "Wrbapi" }
                     },
                     AvarageDuration = 12,
                     LessonsDate = new List<DateTime>
                     {
                         DateTime.UtcNow.AddDays(2),
                         DateTime.UtcNow.AddDays(3),
                         DateTime.UtcNow.AddDays(4)
                     },
                     LinksToChannels = new Dictionary<string, string>()
                     {
                         {"youtube", "stuff" },
                         {"facebook", "morestruff" }
                     },
                     ExpectedAudience = 100,



                     CategoryId = categories[0].Id,
                     CountryId = countries[0].Id,
                     
                     Description = "The greatest online course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
            };
            var investments = new List<Investments>()
            {
                new Investments
                {
                    Amount = 10,
                    
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[0].Id,
                    ItemId = applications[0].Id,
                    Tier = 1
                },
                new Investments
                {
                    Amount = 100,
                    
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[1].Id,
                    ItemId = events[0].Id,
                    Tier = 2
                },new Investments
                {
                    Amount = 10000,
                    
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[1].Id,
                    ItemId = onlineCourses[0].Id,
                    Tier = 3
                },
            };




            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Subcategory>().HasData(subcategories);
            modelBuilder.Entity<Investor>().
                HasData(investors);
            modelBuilder.Entity<Organisation>().HasData(organisations);
            modelBuilder.Entity<Application>().HasData(applications);
            modelBuilder.Entity<OnlineCourse>().HasData(onlineCourses);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<Investments>().HasData(investments);




        }

    }
}

